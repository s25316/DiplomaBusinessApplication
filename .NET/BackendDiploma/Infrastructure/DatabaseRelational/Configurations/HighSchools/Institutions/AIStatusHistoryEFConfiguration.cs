using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AIStatusHistoryEFConfiguration : IEntityTypeConfiguration<AIStatusHistory>
    {
        public void Configure(EntityTypeBuilder<AIStatusHistory> builder)
        {
            builder.ToTable(nameof(AIStatusHistory));
            builder.HasKey(x => new { x.InstitutionId, x.StatusId, x.Date })
                .HasName($"{nameof(AIStatusHistory)}_pk");

            builder.HasOne(x => x.Status)
                .WithMany(x => x.Histories)
                .HasForeignKey(x => x.StatusId)
                .HasConstraintName($"{nameof(AIStatusHistory)}_{nameof(AIStatus)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Institution)
                .WithMany(x => x.StatusHistories)
                .HasForeignKey(x => x.InstitutionId)
                .HasConstraintName($"{nameof(AIStatusHistory)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
