using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.Companies.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies.Statuses
{
    public class CompanyStatusHistoryEFConfiguration : IEntityTypeConfiguration<CompanyStatusHistory>
    {
        public void Configure(EntityTypeBuilder<CompanyStatusHistory> builder)
        {
            builder.ToTable(nameof(CompanyStatusHistory));
            builder.HasKey(x => new { x.CompanyId, x.Date, x.CompanyStatusId })
                .HasName($"{nameof(CompanyStatusHistory)}_pk");

            builder.HasOne(x => x.CompanyStatus)
                .WithMany(x => x.CompanyStatusHistories)
                .HasForeignKey(x => x.CompanyStatusId)
                .HasConstraintName($"{nameof(CompanyStatusHistory)}_{nameof(CompanyStatus)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.CompanyStatusHistories)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(CompanyStatusHistory)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
