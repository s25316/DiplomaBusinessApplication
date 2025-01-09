using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.HighSchools.Courses;
using Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes;

namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AcademicInstitution
    {
        //Properties
        public DateOnly LastUpdate { get; set; }

        //Dependencies
        public Guid AcademicInstitutionId { get; set; }//PK/FK
        public virtual Company Company { get; set; } = null!;
        public int AcademicInstitutionTypeId { get; set; }
        public AIType AcademicInstitutionType { get; set; } = null!;
        public virtual ICollection<AISpecificTypeHistory> SpecificTypeHistories { get; set; } = new List<AISpecificTypeHistory>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
