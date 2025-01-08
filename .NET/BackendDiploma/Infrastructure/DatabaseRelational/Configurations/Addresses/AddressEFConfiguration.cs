using Application.DatabaseRelational.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Addresses
{
    public class AddressEFConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
            builder.HasKey(x => x.AddressId).HasName($"{nameof(Address)}_pk");

            builder.Property(x => x.AddressId)
                .ValueGeneratedNever()
                .HasDefaultValueSql("(newid())");
            builder.Property(x => x.BuildingNumber)
                .HasMaxLength(50);
            builder.Property(x => x.ApartmentNumber)
                .HasMaxLength(50);

            builder.HasOne(x => x.Street)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.StreetId)
                .HasConstraintName($"{nameof(Address)}_{nameof(Street)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Division)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.DivisionId)
                .HasConstraintName($"{nameof(Address)}_{nameof(Division)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
