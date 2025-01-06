using RadonFlatFileDB.DTOs;
using RadonFlatFileDB.Features;
using RadonFlatFileDB.Features.Branches.Entities;
using RadonFlatFileDB.Features.DoctoralSchools;
using RadonFlatFileDB.Features.Institutions.Entities;
using RadonFlatFileDB.Features.Institutions.ValueObjects;
using RadonFlatFileDB.Repositories;

namespace RadonFlatFileDB.Services
{
    public class RadonService : IRadonService
    {
        //Properties
        private readonly IRadonRepository _repository;

        //Constructor
        public RadonService(IRadonRepository repository) { _repository = repository; }


        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Public Methods
        public IEnumerable<Institution> GetInstitutions(string? path = null)
        {
            var coreData = _repository.GetInstitutions(path);
            var list = new List<Institution>();

            foreach (var group in coreData.GroupBy(x => x.Id))
            {
                var names = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.Names))
                    .Select(x => new Change
                    {
                        Value = x.Names ?? "",
                        Date = x.NameDate ?? new DateOnly(),
                    })
                    .ToHashSet();
                var statuses = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.StatusChangeHistory))
                    .Select(x => new Change
                    {
                        Value = x.StatusChangeHistory ?? "",
                        Date = x.StatusChangeDate ?? new DateOnly(),
                    })
                    .ToHashSet();
                var types = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.TypeChangeHistory))
                    .Select(x => new Change
                    {
                        Value = x.TypeChangeHistory ?? "",
                        Date = x.TypeChangeDate ?? new DateOnly(),
                    })
                    .ToHashSet();
                var addresses = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.AddressChangeHistory))
                    .Select(x => new Change
                    {
                        Value = x.AddressChangeHistory ?? "",
                        Date = x.AddressChangeDate ?? new DateOnly(),
                    })
                    .ToHashSet();
                var parentInstitutions = group
                    .Where(x => x.ParentInstitutionId != null)
                    .Select(x => new TransformationInstitution
                    {
                        Id = x.ParentInstitutionId ?? new Guid(),
                        TransformationType = x.ParentInstitutionTransformationType ?? "",
                        Date = x.ParentInstitutionTransformationDate ?? new DateOnly(),
                    })
                    .ToHashSet();
                var succeedingInstitutions = group
                    .Where(x => x.SucceedingInstitutionId != null)
                    .Select(x => new TransformationInstitution
                    {
                        Id = x.SucceedingInstitutionId ?? new Guid(),
                        TransformationType = x.SucceedingInstitutionTransformationType ?? "",
                        Date = x.SucceedingInstitutionTransformationDate ?? new DateOnly(),
                    })
                    .ToHashSet();

                var institution = new Institution
                {
                    Id = group.First().Id,
                    Name = group.First().Name,
                    CreationDate = group.First().CreationDate,
                    InstitutionType = group.First().InstitutionType,
                    IsPan = group.First().IsPan,
                    YearFromPan = group.First().YearFromPan,
                    LiquidationDate = group.First().LiquidationDate,
                    LiquidationStartDate = group.First().LiquidationStartDate,
                    UniversityType = group.First().UniversityType,
                    ScientificInstitutionType = group.First().ScientificInstitutionType,
                    Regon = group.First().Regon,
                    Nip = group.First().Nip,
                    Krs = group.First().Krs,
                    Website = group.First().Website,
                    Email = group.First().Email,
                    Phone = group.First().Phone,
                    City = group.First().City,
                    Country = group.First().Country,
                    Voivodeship = group.First().Voivodeship,
                    StreetAddress = group.First().StreetAddress,
                    AddressNumber = group.First().AddressNumber,
                    PostalCode = group.First().PostalCode,
                    Names = names,
                    StatusChangeHistory = statuses,
                    TypeChangeHistory = types,
                    AddressChangeHistory = addresses,
                    Predecessors = parentInstitutions,
                    Successors = succeedingInstitutions,
                };
                list.Add(institution);
            }
            return list;
        }

        public IEnumerable<Branch> GetBranches(string? path = null)
        {
            var coreData = _repository.GetBranches(path);
            var list = new List<Branch>();

            foreach (var group in coreData.GroupBy(x => x.Id))
            {
                var historiaZmianNazwy = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.HistoriaZmianNazwyNazwa))
                    .Select(x => new Change
                    {
                        Value = x.HistoriaZmianNazwyNazwa ?? "",
                        Date = x.HistoriaZmianNazwyDataNadaniaNazwy ?? new DateOnly(),
                    })
                    .ToHashSet();
                var historiaZmianStatusu = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.HistoriaZmianStatusuStatus))
                    .Select(x => new Change
                    {
                        Value = x.HistoriaZmianStatusuStatus ?? "",
                        Date = x.HistoriaZmianStatusuDataNadaniaStatusu ?? new DateOnly(),
                    })
                    .ToHashSet();
                var historiaZmianAdresu = group
                    .Where(x => !string.IsNullOrWhiteSpace(x.HistoriaZmianAdresuAdres))
                    .Select(x => new Change
                    {
                        Value = x.HistoriaZmianAdresuAdres ?? "",
                        Date = x.HistoriaZmianAdresuDataOtrzymaniaAdresu ?? new DateOnly(),
                    })
                    .ToHashSet();
                var branch = new Branch
                {
                    Id = group.First().Id,
                    NazwaFilii = group.First().NazwaFilii,
                    IdInstytucjiGlownej = group.First().IdInstytucjiGlownej,
                    DataUtworzenia = group.First().DataUtworzenia,
                    DataPostawieniaWStanLikwidacji = group.First().DataPostawieniaWStanLikwidacji,
                    DataLikwidacji = group.First().DataLikwidacji,
                    StronaWWW = group.First().StronaWWW,
                    AdresEmail = group.First().AdresEmail,
                    Telefon = group.First().Telefon,
                    Kraj = group.First().Kraj,
                    Wojewodztwo = group.First().Wojewodztwo,
                    AdresUlica = group.First().AdresUlica,
                    AdresNumer = group.First().AdresNumer,
                    AdresKodPocztowy = group.First().AdresKodPocztowy,
                    AdresMiasto = group.First().AdresMiasto,
                    HistoriaZmianAdresu = historiaZmianAdresu,
                    HistoriaZmianNazwy = historiaZmianNazwy,
                    HistoriaZmianStatusu = historiaZmianStatusu,
                };
                list.Add(branch);
            }
            return list;
        }

        public IEnumerable<DoctoralSchoolPair> GetDoctoralSchools(string? path = null)
        {
            var coreData = _repository.GetDoctoralSchools(path);
            return coreData.Select(x => new DoctoralSchoolPair
            {
                Id = x.Id,
                PodmiotProwadzącyId = x.PodmiotProwadzącyId,
            }).ToHashSet();
        }
        public IEnumerable<KsztalcenieSpecjalistyczneDto> GetSpecialEducations(string? path = null)
        {
            return _repository.GetSpecialEducations(path);
        }
        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Private Methods

        private DateOnly ParseToDateOnly(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? new DateOnly() : DateOnly.Parse(value);
        }
    }
}
