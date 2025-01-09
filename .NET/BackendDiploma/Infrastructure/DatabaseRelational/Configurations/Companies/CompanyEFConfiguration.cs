using Application.DatabaseRelational.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies
{
    public class CompanyEFConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));
            builder.HasKey(x => x.CompanyId).HasName($"{nameof(Company)}_pk");

            builder.Property(x => x.CompanyId).HasDefaultValueSql("(newid())");
        }
    }
}
