using Application.DatabaseRelational.Models.HighSchools.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    public class CourseProfileEFConfiguration : IEntityTypeConfiguration<CourseProfile>
    {
        public void Configure(EntityTypeBuilder<CourseProfile> builder)
        {
            builder.ToTable(nameof(CourseProfile));
            builder.HasKey(x => x.CourseProfileCode).HasName($"{nameof(CourseProfile)}_pk");

            builder.Property(x => x.CourseProfileCode).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.CourseProfile)
                .HasForeignKey(x => x.CourseProfileCode)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseProfile)}")
                .OnDelete(DeleteBehavior.Restrict);

            CourseProfile[] items =
                {
                new CourseProfile{ CourseProfileCode = 1, Name = "praktyczny" },
                new CourseProfile{ CourseProfileCode = 2, Name = "ogólnoakademicki" },
            };
            builder.HasData(items);
        }
    }
}
