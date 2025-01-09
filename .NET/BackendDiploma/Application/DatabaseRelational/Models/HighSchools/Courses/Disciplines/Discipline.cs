namespace Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines
{
    public class Discipline
    {
        //Properties
        public string DisciplineCode { get; set; } = null!;
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<CourseDiscipline> Courses { get; set; } = new List<CourseDiscipline>();
    }
}
