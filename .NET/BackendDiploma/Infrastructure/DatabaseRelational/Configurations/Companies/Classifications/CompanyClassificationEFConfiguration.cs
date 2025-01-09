using Application.DatabaseRelational.Models.Companies.Classifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies.Classifications
{
    public class CompanyClassificationEFConfiguration : IEntityTypeConfiguration<CompanyClassification>
    {
        public void Configure(EntityTypeBuilder<CompanyClassification> builder)
        {
            builder.ToTable(nameof(CompanyClassification));
            builder.HasKey(x => x.CompanyClassificationId)
                .HasName($"{nameof(CompanyClassification)}_pk");

            builder.Property(x => x.CompanyClassificationId).ValueGeneratedNever();
            builder.Property(x => x.Code).HasMaxLength(20);
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
