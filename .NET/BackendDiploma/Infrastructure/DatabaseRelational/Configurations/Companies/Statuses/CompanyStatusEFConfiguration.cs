using Application.DatabaseRelational.Models.Companies.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Companies.Statuses
{
    public class CompanyStatusEFConfiguration : IEntityTypeConfiguration<CompanyStatus>
    {
        public void Configure(EntityTypeBuilder<CompanyStatus> builder)
        {
            builder.ToTable(nameof(CompanyStatus));
            builder.HasKey(x => x.Id).HasName($"{nameof(CompanyStatus)}_pk");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            //https://radon.nauka.gov.pl/opendata/polon/dictionaries/institution/institutionStatuses
            CompanyStatus[] data =
                {
                new CompanyStatus { Id = 1, Name = "Działająca" },
                new CompanyStatus { Id = 4, Name = "Przekształcona" },
                new CompanyStatus { Id = 2, Name = "W likwidacji" },
                new CompanyStatus { Id = 8, Name = "Wykreślona z wykazu" },
                new CompanyStatus { Id = 3, Name = "Zlikwidowana" },

                //(niżej wymienione) W ramach REGON
                new CompanyStatus { Id = 11, Name = "Zawieszona" },
                new CompanyStatus { Id = 12, Name = "Wznowiona" },
                new CompanyStatus { Id = 13, Name = "Zakończona" },
            };
            builder.HasData(data);
        }
    }
}
