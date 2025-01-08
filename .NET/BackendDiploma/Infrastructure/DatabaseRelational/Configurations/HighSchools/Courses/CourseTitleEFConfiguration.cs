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
            builder.HasKey(x => x.Code).HasName($"{nameof(CourseTitle)}_pk");

            builder.Property(x => x.Code).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Title)
                .HasForeignKey(x => x.TitleCode)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseTitle)}")
                .OnDelete(DeleteBehavior.Restrict);

            CourseTitle[] items =
                {
                new CourseTitle{ Code = 1, Name = "magister" },
                new CourseTitle{ Code = 2, Name = "licencjat" },
                new CourseTitle{ Code = 3, Name = "inżynier" },
                new CourseTitle{ Code = 4, Name = "magister inżynier" },
            };
            builder.HasData(items);
        }
    }
}
