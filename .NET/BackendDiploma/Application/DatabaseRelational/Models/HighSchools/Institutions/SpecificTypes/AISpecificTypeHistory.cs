namespace Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes
{
    public class AISpecificTypeHistory
    {
        //Properties
        public DateOnly Date { get; set; }

        //Dependencies
        public int TypeId { get; set; }
        public virtual AISpecificType Type { get; set; } = null!;
        public Guid InstitutionId { get; set; }
        public virtual AcademicInstitution Institution { get; set; } = null!;
    }
}
