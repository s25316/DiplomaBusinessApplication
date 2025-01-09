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
            builder.HasKey(x => new { x.InstitutionId, x.TypeId, x.Date })
                .HasName($"{nameof(AISpecificTypeHistory)}_pk");

            builder.HasOne(x => x.Institution)
                .WithMany(x => x.SpecificTypeHistories)
                .HasForeignKey(x => x.InstitutionId)
                .HasConstraintName($"{nameof(AISpecificTypeHistory)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.Histories)
                .HasForeignKey(x => x.TypeId)
                .HasConstraintName($"{nameof(AISpecificTypeHistory)}_{nameof(AISpecificType)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
