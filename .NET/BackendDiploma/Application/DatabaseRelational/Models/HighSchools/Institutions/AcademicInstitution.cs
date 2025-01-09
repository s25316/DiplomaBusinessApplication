using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes;

namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AcademicInstitution
    {
        //Properties
        public DateOnly LastUpdate { get; set; }

        //Dependencies
        public Guid Id { get; set; }//PK
        public virtual Company Company { get; set; } = null!;
        public int TypeId { get; set; }
        public AIType Type { get; set; } = null!;
        public virtual ICollection<AISpecificTypeHistory> SpecificTypeHistories { get; set; } = new List<AISpecificTypeHistory>();
    }
}
