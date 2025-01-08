using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AINameHistoryEFConfiguration : IEntityTypeConfiguration<AINameHistory>
    {
        public void Configure(EntityTypeBuilder<AINameHistory> builder)
        {
            builder.ToTable(nameof(AINameHistory));
            builder.HasKey(x => new { x.InstitutionId, x.Date })
                .HasName($"{nameof(AINameHistory)}_pk");

            builder.Property(x => x.Name).HasMaxLength(800);

            builder.HasOne(x => x.Institution)
                .WithMany(x => x.NameHistories)
                .HasForeignKey(x => x.InstitutionId)
                .HasConstraintName($"{nameof(AINameHistory)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
