using Application.DatabaseRelational.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies
{
    public class CompanyNameHistoryEFConfiguration : IEntityTypeConfiguration<CompanyNameHistory>
    {
        public void Configure(EntityTypeBuilder<CompanyNameHistory> builder)
        {
            builder.ToTable(nameof(CompanyNameHistory));
            builder.HasKey(x => new { x.CompanyId, x.Date })
                .HasName($"{nameof(CompanyNameHistory)}_pk");

            builder.Property(x => x.Name).HasMaxLength(800);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.NamesHistory)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(CompanyNameHistory)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
