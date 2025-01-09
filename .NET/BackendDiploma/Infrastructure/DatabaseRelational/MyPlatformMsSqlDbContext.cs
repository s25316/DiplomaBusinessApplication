using Application.DatabaseRelational;
using Application.DatabaseRelational.Models.Addresses;
using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.Companies.Classifications;
using Application.DatabaseRelational.Models.Companies.Identifiers;
using Application.DatabaseRelational.Models.Companies.Statuses;
using Application.DatabaseRelational.Models.HighSchools.Courses;
using Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines;
using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes;
using Infrastructure.DatabaseRelational.Configurations.Addresses;
using Infrastructure.DatabaseRelational.Configurations.Companies;
using Infrastructure.DatabaseRelational.Configurations.Companies.Classifications;
using Infrastructure.DatabaseRelational.Configurations.Companies.Identifiers;
using Infrastructure.DatabaseRelational.Configurations.Companies.Statuses;
using Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses;
using Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses.Disciplines;
using Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions;
using Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions.AISpecificTypes;
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
            modelBuilder.ApplyConfiguration<AISpecificType>(new AISpecificTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<AISpecificTypeHistory>(new AISpecificTypeHistoryEFConfiguration());
            modelBuilder.ApplyConfiguration<AIType>(new AITypeEFConfiguration());
            //HighSchools.Courses
            modelBuilder.ApplyConfiguration<CourseDiscipline>(new CourseDisciplineEFConfiguration());
            modelBuilder.ApplyConfiguration<Course>(new CourseEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseForm>(new CourseFormEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseLevel>(new CourseLevelEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseProfile>(new CourseProfileEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseTitle>(new CourseTitleEFConfiguration());
            modelBuilder.ApplyConfiguration<Discipline>(new DisciplineEFConfiguration());
            modelBuilder.ApplyConfiguration<Isced>(new IscedEFConfiguration());
            modelBuilder.ApplyConfiguration<Language>(new LanguageEFConfiguration());
            modelBuilder.ApplyConfiguration<AIOrganizationalUnit>(new AIOrganizationalUnitEFConfiguration());
            //Company
            modelBuilder.ApplyConfiguration<Company>(new CompanyEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyNameHistory>(new CompanyNameHistoryEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyStatus>(new CompanyStatusEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyStatusHistory>(new CompanyStatusHistoryEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyIdentifier>(new CompanyIdentifierEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyIdentifierDetail>(new CompanyIdentifierDetailEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyClassification>(new CompanyClassificationEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyClassificationDetail>(new CompanyClassificationDetailEFConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
