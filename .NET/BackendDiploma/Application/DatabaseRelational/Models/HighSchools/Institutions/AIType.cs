namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AIType
    {
        //Properties
        public int AcademicInstitutionTypeId { get; set; }
        public bool IsSchool { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<AcademicInstitution> AcademicInstitutions { get; set; } = new List<AcademicInstitution>();
    }
}
