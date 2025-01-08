using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AITypeEFConfiguration : IEntityTypeConfiguration<AIType>
    {
        public void Configure(EntityTypeBuilder<AIType> builder)
        {
            builder.ToTable(nameof(AIType));
            builder.HasKey(x => x.Id).HasName($"{nameof(AIType)}_pk");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.IsSchool).HasDefaultValue((false));

            builder.HasMany(x => x.Institutions)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .HasConstraintName($"{nameof(AIType)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
