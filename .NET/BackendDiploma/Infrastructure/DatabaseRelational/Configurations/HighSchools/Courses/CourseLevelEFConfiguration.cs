using Application.DatabaseRelational.Models.HighSchools.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    public class CourseLevelEFConfiguration : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder.ToTable(nameof(CourseLevel));
            builder.HasKey(x => x.Code).HasName($"{nameof(CourseLevel)}_pk");

            builder.Property(x => x.Code).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Level)
                .HasForeignKey(x => x.LevelCode)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseLevel)}")
                .OnDelete(DeleteBehavior.Restrict);

            CourseLevel[] items =
                {
                new CourseLevel{ Code = 1, Name = "jednolite magisterskie" },
                new CourseLevel{ Code = 2, Name = "pierwszego stopnia" },
                new CourseLevel{ Code = 3, Name = "drugiego stopnia" },
            };
            builder.HasData(items);
        }
    }
}
