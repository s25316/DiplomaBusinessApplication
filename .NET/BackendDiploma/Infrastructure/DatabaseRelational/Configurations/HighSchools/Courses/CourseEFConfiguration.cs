using Application.DatabaseRelational.Models.HighSchools.Courses;
using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    internal class CourseEFConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.HasKey(x => x.CourseId).HasName($"{nameof(Course)}_pk");

            builder.Property(x => x.Name).HasMaxLength(800);
            builder.Property(x => x.LastUpdate).HasDefaultValueSql("(GETDATE())");

            builder.HasOne(x => x.AcademicInstitution)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.AcademicInstitutionId)
                .HasConstraintName($"{nameof(AcademicInstitution)}_{nameof(Course)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
