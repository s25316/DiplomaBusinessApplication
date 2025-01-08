namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AIStatusHistory
    {
        //Properties
        public Guid InstitutionId { get; set; }
        public int StatusId { get; set; }
        public DateOnly Date { get; set; }

        //Dependencies
        public virtual AcademicInstitution Institution { get; set; } = null!;
        public virtual AIStatus Status { get; set; } = null!;
    }
}
