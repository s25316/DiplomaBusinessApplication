using Application.DatabaseRelational.Models.Addresses;
using Application.DatabaseRelational.Models.Companies.Classifications;
using Application.DatabaseRelational.Models.Companies.Identifiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Addresses
{
    public class CountryEFConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));
            builder.HasKey(x => x.CountryId).HasName($"{nameof(Country)}_pk");

            builder.Property(x => x.CountryId)
                .ValueGeneratedNever();
            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasMany(x => x.Divisions)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName($"{nameof(Country)}_{nameof(Division)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Streets)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName($"{nameof(Country)}_{nameof(Street)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CompanyIdentifierTypes)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName($"{nameof(Country)}_{nameof(CompanyIdentifier)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CompanyClassificationTypes)
               .WithOne(x => x.Country)
               .HasForeignKey(x => x.CountryId)
               .HasConstraintName($"{nameof(Country)}_{nameof(CompanyClassification)}")
               .OnDelete(DeleteBehavior.Restrict);

            Country[] data =
                {
                new Country{ CountryId = 1, Name = "Polska"},
            };
            builder.HasData(data);
        }
    }
}
