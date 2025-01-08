using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AIStatusEFConfiguration : IEntityTypeConfiguration<AIStatus>
    {
        public void Configure(EntityTypeBuilder<AIStatus> builder)
        {
            builder.ToTable(nameof(AIStatus));
            builder.HasKey(x => x.Id).HasName($"{nameof(AIStatus)}_pk");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
