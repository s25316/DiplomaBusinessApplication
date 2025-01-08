using Application.DatabaseRelational.Models.HighSchools.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    public class CourseFormEFConfiguration : IEntityTypeConfiguration<CourseForm>
    {
        public void Configure(EntityTypeBuilder<CourseForm> builder)
        {
            builder.ToTable(nameof(CourseForm));
            builder.HasKey(x => x.Code).HasName($"{nameof(CourseForm)}_pk");

            builder.Property(x => x.Code).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormCode)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseForm)}")
                .OnDelete(DeleteBehavior.Restrict);

            CourseForm[] items =
                {
                new CourseForm{ Code = 1, Name = "stacjonarne" },
                new CourseForm{ Code = 2, Name = "niestacjonarne" },
            };
            builder.HasData(items);
        }
    }
}
