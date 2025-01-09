using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions.AISpecificTypes
{
    public class AISpecificTypeHistoryEFConfiguration : IEntityTypeConfiguration<AISpecificTypeHistory>
    {
        public void Configure(EntityTypeBuilder<AISpecificTypeHistory> builder)
        {
            builder.ToTable(nameof(AISpecificTypeHistory));
            builder.HasKey(x => new { x.AcademicInstitutionId, x.AcademicInstitutionSpecificTypeId, x.Date })
                .HasName($"{nameof(AISpecificTypeHistory)}_pk");

            builder.HasOne(x => x.AcademicInstitution)
                .WithMany(x => x.SpecificTypeHistories)
                .HasForeignKey(x => x.AcademicInstitutionId)
                .HasConstraintName($"{nameof(AISpecificTypeHistory)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AcademicInstitutionSpecificType)
                .WithMany(x => x.SpecificTypeHistories)
                .HasForeignKey(x => x.AcademicInstitutionSpecificTypeId)
                .HasConstraintName($"{nameof(AISpecificTypeHistory)}_{nameof(AISpecificType)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
