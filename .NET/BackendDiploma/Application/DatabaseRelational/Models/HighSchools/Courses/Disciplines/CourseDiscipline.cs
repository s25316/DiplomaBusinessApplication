namespace Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines
{
    public class CourseDiscipline
    {
        //Properties
        public int? PercentageShare { get; set; } = null;
        public bool? DisciplineLeading { get; set; } = null;

        //Dependencies
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;
        public string DisciplineCode { get; set; } = null!;
        public virtual Discipline Discipline { get; set; } = null!;
    }
}
