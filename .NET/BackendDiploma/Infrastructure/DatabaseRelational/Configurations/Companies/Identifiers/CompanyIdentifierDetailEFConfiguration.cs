using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.Companies.Identifiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies.Identifiers
{
    public class CompanyIdentifierDetailEFConfiguration : IEntityTypeConfiguration<CompanyIdentifierDetail>
    {
        public void Configure(EntityTypeBuilder<CompanyIdentifierDetail> builder)
        {
            builder.ToTable(nameof(CompanyIdentifierDetail));
            builder.HasKey(x => new { x.CompanyId, x.IdentifierId })
                .HasName($"{nameof(CompanyIdentifierDetail)}_pk");

            builder.Property(x => x.Value).HasMaxLength(100);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Identifiers)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(CompanyIdentifierDetail)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Identifier)
                .WithMany(x => x.Identifiers)
                .HasForeignKey(x => x.IdentifierId)
                .HasConstraintName($"{nameof(CompanyIdentifierDetail)}_{nameof(CompanyIdentifier)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
