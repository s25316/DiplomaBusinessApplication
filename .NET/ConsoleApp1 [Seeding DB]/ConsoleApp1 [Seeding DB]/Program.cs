using ConsoleApp1__Seeding_DB_.Database;
using RadonFlatFileDB.Repositories;
using RadonFlatFileDB.Services;
using Teryt.Repositories;

namespace ConsoleApp1__Seeding_DB_
{
    internal class Program
    {
        //Scaffold-DbContext "Data Source=localhost;Initial Catalog=Diploma2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Database
        static async Task Main(string[] args)
        {
            var context = new Diploma2Context();
            var radon = new RadonService(new RadonRepository());
            //await FillAddressesDBAsync(context);
            //await FillAcademicInstitutionAsync(radon, context);

        }

        private static async Task FillAcademicInstitutionAsync(
            IRadonService service,
            Diploma2Context context)
        {
            var institutions = service.GetInstitutions();

            var baseTypes = institutions.Select(x => x.InstitutionType)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToHashSet();
            var specificTypes = institutions
                .Where(x => x.TypeChangeHistory.Any())
                .SelectMany(x => x.TypeChangeHistory.Select(y => y.Value))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToHashSet();
            var statuses = institutions
                .Where(x => x.StatusChangeHistory.Any())
                .SelectMany(x => x.StatusChangeHistory.Select(y => y.Value))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToHashSet();

            int counter = 1;
            var aitypes = baseTypes.Select(x => new Aitype
            {
                Id = counter++,
                IsSchool = x.ToLower().Contains("uczelnia"),
                Name = x,
            }).ToDictionary(x => x.Name);

            counter = 1;
            var aispecificTypes = specificTypes.Select(x => new AispecificType
            {
                Id = counter++,
                Name = x,
            }).ToDictionary(x => x.Name);

            counter = 1;
            var aistatuses = statuses.Select(x => new Aistatus
            {
                Id = counter++,
                Name = x,
            }).ToDictionary(x => x.Name);

            var dbInstitutions = institutions.Select(x => new AcademicInstitution
            {
                Id = x.Id,
                ParentId = null,
                Name = x.Name,
                CreationDate = x.CreationDate,
                LiquidationDate = x.LiquidationDate,
                LiquidationStartDate = x.LiquidationStartDate,
                Www = x.Website,
                Email = x.Email,
                Phone = x.Phone,
                Type = aitypes[x.InstitutionType],
                AinameHistories = x.Names.Select(name => new AinameHistory
                {
                    InstitutionId = x.Id,
                    Name = name.Value,
                    Date = name.Date,
                }).ToHashSet(),
                AispecificTypeHistories = x.TypeChangeHistory.Select(speceficType => new AispecificTypeHistory
                {
                    InstitutionId = x.Id,
                    Type = aispecificTypes[speceficType.Value.Trim()],
                    Date = speceficType.Date,
                }).ToHashSet(),
                AistatusHistories = x.StatusChangeHistory.Select(status => new AistatusHistory
                {
                    InstitutionId = x.Id,
                    Status = aistatuses[status.Value],
                    Date = status.Date,
                }).ToHashSet(),
            }).ToHashSet();


            await context.Aitypes.AddRangeAsync(aitypes.Values);
            await context.AispecificTypes.AddRangeAsync(aispecificTypes.Values);
            await context.Aistatuses.AddRangeAsync(aistatuses.Values);
            await context.AcademicInstitutions.AddRangeAsync(dbInstitutions);

            await context.SaveChangesAsync();
        }


        private static async Task FillAddressesDBAsync(Diploma2Context context)
        {
            var teryt = new TerytRepository();
            var data = await teryt.GetFullDataAsync(1, 1, 1, 1);

            var polska = new Country
            {
                CountryId = 1,
                Name = "Polska",
            };

            var divisionTypes = data.AdministrativeTypes.Select(x => new DivisionType
            {
                DivisionTypeId = (int)x.Value.Id,
                Name = x.Value.Name,
            });

            var divisions = data.Divisions.Select(x => new Division
            {
                DivisionId = (int)x.Value.Id,
                ParentDivisionId = (int?)x.Value.ParentId,
                CountryId = 1,
                Name = x.Value.Name,
                DivisionTypeId = (int)x.Value.Type.Id
            }).ToDictionary(x => x.DivisionId);

            var streets = data.Streets.Select(x => new Street
            {
                StreetId = (int)x.Value.Id,
                Name = $"{x.Value.Nazwa1} {x.Value.Nazwa2}",
                DivisionTypeId = (int?)x.Value.Cecha?.Id,
                CountryId = 1,
            }).ToDictionary(x => x.StreetId);

            foreach (var group in data.Collocations.GroupBy(x => x.DivisionId))
            {
                var division = divisions[(int)group.Key];
                foreach (var colocation in group)
                {
                    var street = streets[(int)colocation.StreetId];
                    division.Streets.Add(street);
                }
            }

            await context.Countries.AddAsync(polska);
            await context.DivisionTypes.AddRangeAsync(divisionTypes);
            await context.Divisions.AddRangeAsync(divisions.Values);
            await context.Streets.AddRangeAsync(streets.Values);
            await context.SaveChangesAsync();
        }
    }
}
