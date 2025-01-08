namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AINameHistory
    {
        //Properties
        public Guid InstitutionId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }

        //Dependencies
        public virtual AcademicInstitution Institution { get; set; } = null!;
    }
}
