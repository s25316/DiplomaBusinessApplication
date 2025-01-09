using Application.DatabaseRelational.Models.HighSchools.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    public class CourseTitleEFConfiguration : IEntityTypeConfiguration<CourseTitle>
    {
        public void Configure(EntityTypeBuilder<CourseTitle> builder)
        {
            builder.ToTable(nameof(CourseTitle));
            builder.HasKey(x => x.CourseTitleCode).HasName($"{nameof(CourseTitle)}_pk");

            builder.Property(x => x.CourseTitleCode).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.CourseTitle)
                .HasForeignKey(x => x.CourseTitleCode)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseTitle)}")
                .OnDelete(DeleteBehavior.Restrict);

            CourseTitle[] items =
                {
                new CourseTitle{ CourseTitleCode = 1, Name = "magister" },
                new CourseTitle{ CourseTitleCode = 2, Name = "licencjat" },
                new CourseTitle{ CourseTitleCode = 3, Name = "inżynier" },
                new CourseTitle{ CourseTitleCode = 4, Name = "magister inżynier" },
            };
            builder.HasData(items);
        }
    }
}
