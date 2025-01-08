namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfSemesters { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? LiquidationDate { get; set; } = null;
        public virtual int? FormCode { get; set; } = null!;
        public virtual CourseForm? Form { get; set; } = null!;
        public virtual int? TitleCode { get; set; } = null!;
        public virtual CourseTitle? Title { get; set; } = null!;
        public virtual int? LevelCode { get; set; } = null!;
        public virtual CourseLevel? Level { get; set; } = null!;
        public virtual int? ProfileCode { get; set; } = null!;
        public virtual CourseProfile? Profile { get; set; } = null!;
        public virtual string? LanguageCode { get; set; } = null!;
        public virtual Language? Language { get; set; } = null!;
        public virtual string IscedCode { get; set; } = null!;
        public virtual Isced Isced { get; set; } = null!;
        public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
        public virtual ICollection<CourseDiscipline> Disciplines { get; set; } = new List<CourseDiscipline>();
        public virtual ICollection<AIOrganizationalUnit> OrganizationalUnits { get; set; } = new List<AIOrganizationalUnit>();
    }
}
