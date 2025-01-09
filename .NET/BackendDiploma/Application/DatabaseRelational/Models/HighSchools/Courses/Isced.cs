namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class Isced
    {
        //Properties
        public string IscedCode { get; set; } = null!;
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
