using Application.DatabaseRelational.Models.Companies.Identifiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies.Identifiers
{
    public class CompanyIdentifierEFConfiguration : IEntityTypeConfiguration<CompanyIdentifier>
    {
        public void Configure(EntityTypeBuilder<CompanyIdentifier> builder)
        {
            builder.ToTable(nameof(CompanyIdentifier));
            builder.HasKey(x => x.Id).HasName($"{nameof(CompanyIdentifier)}_pk");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.ShortName).HasMaxLength(20);
            builder.Property(x => x.Name).HasMaxLength(100);

            CompanyIdentifier[] data = {
                new CompanyIdentifier{ Id = 1, ShortName = "NIP", Name = "Numer identyfikacji podatkowej", CountryId = 1},
                new CompanyIdentifier{ Id = 2, ShortName = "REGON", Name = "Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej", CountryId = 1},
                new CompanyIdentifier{ Id = 3, ShortName = "KRS", Name = "Krajowy Rejestr Sądowy", CountryId = 1},
            };
            builder.HasData(data);
        }
    }
}
