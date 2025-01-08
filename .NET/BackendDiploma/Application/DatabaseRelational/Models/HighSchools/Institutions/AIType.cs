namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AIType
    {
        //Properties
        public int Id { get; set; }
        public bool IsSchool { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<AcademicInstitution> Institutions { get; set; } = new List<AcademicInstitution>();
    }
}
