using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.Companies.Classifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies.Classifications
{
    internal class CompanyClassificationDetailEFConfiguration : IEntityTypeConfiguration<CompanyClassificationDetail>
    {
        public void Configure(EntityTypeBuilder<CompanyClassificationDetail> builder)
        {
            builder.ToTable(nameof(CompanyClassificationDetail));
            builder.HasKey(x => new { x.CompanyId, x.ClassificationId })
                .HasName($"{nameof(CompanyClassificationDetail)}_pk");

            builder.Property(x => x.IsMain).HasDefaultValue((false));

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Classifications)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(CompanyClassificationDetail)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Classification)
                .WithMany(x => x.Classifications)
                .HasForeignKey(x => x.ClassificationId)
                .HasConstraintName($"{nameof(CompanyClassificationDetail)}_{nameof(CompanyClassification)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
