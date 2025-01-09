namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class Language
    {
        //Properties
        public string LanguageCode { get; set; } = null!;
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<Course> CourseLanguage { get; set; } = new List<Course>();
        public virtual ICollection<Course> CourseLanguages { get; set; } = new List<Course>();

    }
}
