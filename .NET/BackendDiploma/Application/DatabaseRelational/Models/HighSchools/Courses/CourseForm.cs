namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class CourseForm
    {
        //Properties
        public int CourseFormCode { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
