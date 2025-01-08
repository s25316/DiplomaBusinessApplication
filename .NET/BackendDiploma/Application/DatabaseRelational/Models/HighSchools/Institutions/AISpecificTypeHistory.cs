namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AISpecificTypeHistory
    {
        //Properties
        public Guid InstitutionId { get; set; }
        public int TypeId { get; set; }
        public DateOnly Date { get; set; }

        //Dependencies
        public virtual AcademicInstitution Institution { get; set; } = null!;
        public virtual AISpecificType Type { get; set; } = null!;
    }
}
