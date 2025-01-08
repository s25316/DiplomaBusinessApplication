using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AISpecificTypeEFConfiguration : IEntityTypeConfiguration<AISpecificType>
    {
        public void Configure(EntityTypeBuilder<AISpecificType> builder)
        {
            builder.ToTable(nameof(AISpecificType));
            builder.HasKey(x => x.Id).HasName($"{nameof(AISpecificType)}_pk");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
