namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class CourseProfile
    {
        //Properties
        public int CourseProfileCode { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
