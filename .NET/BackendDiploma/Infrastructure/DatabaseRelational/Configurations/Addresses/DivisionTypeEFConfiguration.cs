using Application.DatabaseRelational.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Addresses
{
    public class DivisionTypeEFConfiguration : IEntityTypeConfiguration<DivisionType>
    {
        public void Configure(EntityTypeBuilder<DivisionType> builder)
        {
            builder.ToTable(nameof(DivisionType));
            builder.HasKey(x => x.DivisionTypeId).HasName($"{nameof(DivisionType)}_pk");

            builder.Property(x => x.DivisionTypeId).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.Divisions)
                .WithOne(x => x.DivisionType)
                .HasForeignKey(x => x.DivisionTypeId)
                .HasConstraintName($"{nameof(DivisionType)}_{nameof(Division)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Streets)
                .WithOne(x => x.DivisionType)
                .HasForeignKey(x => x.DivisionTypeId)
                .HasConstraintName($"{nameof(DivisionType)}_{nameof(Street)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
