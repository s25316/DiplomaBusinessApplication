using Application.DatabaseRelational.Models.Addresses;
using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.Companies.Classifications;
using Application.DatabaseRelational.Models.Companies.Identifiers;
using Application.DatabaseRelational.Models.Companies.Statuses;
using Application.DatabaseRelational.Models.HighSchools.Courses;
using Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines;
using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes;
using Microsoft.EntityFrameworkCore;

namespace Application.DatabaseRelational
{
    public class MyPlatformDbContext : DbContext
    {
        public MyPlatformDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MyPlatformDbContext()
        {
        }

        //Addresses
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<DivisionType> DivisionTypes { get; set; }

        //HighSchools/Institutions
        public virtual DbSet<AcademicInstitution> AcademicInstitutions { get; set; }
        public virtual DbSet<AISpecificType> AISpecificTypes { get; set; }
        public virtual DbSet<AISpecificTypeHistory> AISpecificTypeHistories { get; set; }
        public virtual DbSet<AIType> AITypes { get; set; }
        //HighSchools.Courses
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseForm> CourseForms { get; set; }
        public virtual DbSet<CourseTitle> CourseTitles { get; set; }
        public virtual DbSet<CourseLevel> CourseLevels { get; set; }
        public virtual DbSet<CourseProfile> CourseProfiles { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Isced> Isceds { get; set; }
        public virtual DbSet<CourseDiscipline> CourseDisciplines { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<AIOrganizationalUnit> OrganizationalUnits { get; set; }
        //Company
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyNameHistory> CompanyNames { get; set; }
        public virtual DbSet<CompanyStatus> CompanyStatuses { get; set; }
        public virtual DbSet<CompanyStatusHistory> CompanyStatusHistories { get; set; }
        public virtual DbSet<CompanyIdentifier> CompanyIdentifiers { get; set; }
        public virtual DbSet<CompanyIdentifierDetail> CompanyIdentifierDetails { get; set; }
        public virtual DbSet<CompanyClassification> CompanyClassifications { get; set; }
        public virtual DbSet<CompanyClassificationDetail> CompanyClassificationDetails { get; set; }

    }
}
