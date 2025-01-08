using Application.DatabaseRelational.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Addresses
{
    public class StreetEFConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.ToTable(nameof(Street));
            builder.HasKey(x => x.StreetId).HasName($"{nameof(Street)}_pk");

            builder.Property(x => x.StreetId).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
