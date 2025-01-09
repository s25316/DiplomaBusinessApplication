using Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines;
using Application.DatabaseRelational.Models.HighSchools.Institutions;

namespace Application.DatabaseRelational.Models.HighSchools.Courses
{
    public class Course
    {
        //Properties
        public Guid CourseId { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfSemesters { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? LiquidationDate { get; set; } = null;
        public DateOnly LastUpdate { get; set; }

        //Dependencies
        public virtual Guid AcademicInstitutionId { get; set; }
        public virtual AcademicInstitution AcademicInstitution { get; set; } = null!;
        public virtual int? CourseFormCode { get; set; } = null;
        public virtual CourseForm? CourseForm { get; set; } = null;
        public virtual int? CourseTitleCode { get; set; } = null;
        public virtual CourseTitle? CourseTitle { get; set; } = null;
        public virtual int? CourseLevelCode { get; set; } = null;
        public virtual CourseLevel? CourseLevel { get; set; } = null;
        public virtual int? CourseProfileCode { get; set; } = null;
        public virtual CourseProfile? CourseProfile { get; set; } = null;
        public virtual string? LanguageCode { get; set; } = null;
        public virtual Language? Language { get; set; } = null;
        public virtual string IscedCode { get; set; } = null!;
        public virtual Isced Isced { get; set; } = null!;
        public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
        public virtual ICollection<CourseDiscipline> CourseDisciplines { get; set; } = new List<CourseDiscipline>();
        public virtual ICollection<AIOrganizationalUnit> AcademicInstitutionOrganizationalUnits { get; set; } = new List<AIOrganizationalUnit>();

    }
}
