using Application.DatabaseRelational.Models.Addresses;
using Application.DatabaseRelational.Models.HighSchools.Institutions;
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
        public virtual DbSet<AINameHistory> AINameHistories { get; set; }
        public virtual DbSet<AISpecificType> AISpecificTypes { get; set; }
        public virtual DbSet<AISpecificTypeHistory> AISpecificTypeHistories { get; set; }
        public virtual DbSet<AIStatus> AIStatuses { get; set; }
        public virtual DbSet<AIStatusHistory> AIStatusHistories { get; set; }
        public virtual DbSet<AIType> AITypes { get; set; }

    }
}
