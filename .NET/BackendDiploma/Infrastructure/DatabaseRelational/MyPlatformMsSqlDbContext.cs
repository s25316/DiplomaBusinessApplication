using Application.DatabaseRelational;
using Application.DatabaseRelational.Models.Addresses;
using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Infrastructure.DatabaseRelational.Configurations.Addresses;
using Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Add-Migration First -Project Infrastructure -Context MyPlatformMsSqlDbContext
// Update-Database -Project Infrastructure -Context MyPlatformMsSqlDbContext
namespace Infrastructure.DatabaseRelational
{
    public class MyPlatformMsSqlDbContext : MyPlatformDbContext
    {
        //Fields
        private readonly IConfiguration _configuration;
        private readonly string _dbString;


        public MyPlatformMsSqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbString = configuration.GetConnectionString("MsSqlStrig") ??
                throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Addresses
            modelBuilder.ApplyConfiguration<Address>(new AddressEFConfiguration());
            modelBuilder.ApplyConfiguration<Street>(new StreetEFConfiguration());
            modelBuilder.ApplyConfiguration<Division>(new DivisionEFConfiguration());
            modelBuilder.ApplyConfiguration<DivisionType>(new DivisionTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<Country>(new CountryEFConfiguration());
            //HighSchools.Institutions
            modelBuilder.ApplyConfiguration<AcademicInstitution>(new AcademicInstitutionEFConfiguration());
            modelBuilder.ApplyConfiguration<AINameHistory>(new AINameHistoryEFConfiguration());
            modelBuilder.ApplyConfiguration<AISpecificTypeHistory>(new AISpecificTypeHistoryEFConfiguration());
            modelBuilder.ApplyConfiguration<AISpecificType>(new AISpecificTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<AIType>(new AITypeEFConfiguration());
            modelBuilder.ApplyConfiguration<AIStatusHistory>(new AIStatusHistoryEFConfiguration());
            modelBuilder.ApplyConfiguration<AIStatus>(new AIStatusEFConfiguration());
            //
            base.OnModelCreating(modelBuilder);
        }
    }
}
