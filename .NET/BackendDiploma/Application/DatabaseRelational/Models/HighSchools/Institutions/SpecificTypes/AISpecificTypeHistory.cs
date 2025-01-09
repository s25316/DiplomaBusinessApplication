namespace Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes
{
    public class AISpecificTypeHistory
    {
        //Properties
        public DateOnly Date { get; set; }

        //Dependencies
        public int AcademicInstitutionSpecificTypeId { get; set; }
        public virtual AISpecificType AcademicInstitutionSpecificType { get; set; } = null!;
        public Guid AcademicInstitutionId { get; set; }
        public virtual AcademicInstitution AcademicInstitution { get; set; } = null!;
    }
}
