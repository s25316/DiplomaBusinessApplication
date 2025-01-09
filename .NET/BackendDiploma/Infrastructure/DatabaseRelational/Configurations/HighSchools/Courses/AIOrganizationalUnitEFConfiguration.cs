using Application.DatabaseRelational.Models.HighSchools.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    public class AIOrganizationalUnitEFConfiguration : IEntityTypeConfiguration<AIOrganizationalUnit>
    {
        public void Configure(EntityTypeBuilder<AIOrganizationalUnit> builder)
        {
            builder.ToTable(nameof(AIOrganizationalUnit));
            builder.HasKey(x => x.AcademicInstitutionOrganizationalUnitId).HasName($"{nameof(AIOrganizationalUnit)}_pk");

            builder.Property(x => x.Name).HasMaxLength(800);

            builder.HasMany(x => x.Courses)
                .WithMany(x => x.AcademicInstitutionOrganizationalUnits)
                .UsingEntity<Dictionary<string, object>>(
                    $"{nameof(Course)}{nameof(AIOrganizationalUnit)}",
                    r => r.HasOne<Course>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Course.CourseId)}")
                    .HasConstraintName($"{nameof(Course)}{nameof(AIOrganizationalUnit)}_{nameof(Course)}")
                    .OnDelete(DeleteBehavior.Cascade),
                    l => l.HasOne<AIOrganizationalUnit>()
                    .WithMany()
                    .HasForeignKey($"{nameof(AIOrganizationalUnit.AcademicInstitutionOrganizationalUnitId)}")
                    .HasConstraintName($"{nameof(Course)}{nameof(AIOrganizationalUnit)}_{nameof(AIOrganizationalUnit)}")
                    .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
