namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class CourseDiscipline
    {
        //Properties
        public string DisciplineCode { get; set; } = null!;
        public Guid CourseId { get; set; }
        public int? PercentageShare { get; set; } = null;
        public bool? DisciplineLeading { get; set; } = null;

        //Dependencies
        public virtual Course Course { get; set; } = null!;
        public virtual Discipline Discipline { get; set; } = null!;
    }
}
