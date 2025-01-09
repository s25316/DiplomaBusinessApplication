using Application.DatabaseRelational.Models.HighSchools.Courses;
using Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses.Disciplines
{
    public class CourseDisciplineEFConfiguration : IEntityTypeConfiguration<CourseDiscipline>
    {
        public void Configure(EntityTypeBuilder<CourseDiscipline> builder)
        {
            builder.ToTable(nameof(CourseDiscipline));
            builder.HasKey(x => new { x.DisciplineCode, x.CourseId })
                .HasName($"{nameof(CourseDiscipline)}_pk");

            builder.HasOne(x => x.Discipline)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.DisciplineCode)
                .HasConstraintName($"{nameof(CourseDiscipline)}_{nameof(Discipline)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseDisciplines)
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName($"{nameof(CourseDiscipline)}_{nameof(Course)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
