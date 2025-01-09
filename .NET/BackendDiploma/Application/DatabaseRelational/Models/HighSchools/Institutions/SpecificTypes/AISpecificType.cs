namespace Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes
{
    public class AISpecificType
    {
        //Properties
        public int AcademicInstitutionSpecificTypeId { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<AISpecificTypeHistory> SpecificTypeHistories { get; set; } = new List<AISpecificTypeHistory>();
    }
}
