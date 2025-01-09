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
            builder.HasKey(x => x.CompanyStatusId).HasName($"{nameof(CompanyStatus)}_pk");

            builder.Property(x => x.CompanyStatusId).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);

            //https://radon.nauka.gov.pl/opendata/polon/dictionaries/institution/institutionStatuses
            CompanyStatus[] data =
                {
                new CompanyStatus { CompanyStatusId = 1, Name = "Działająca" },
                new CompanyStatus { CompanyStatusId = 4, Name = "Przekształcona" },
                new CompanyStatus { CompanyStatusId = 2, Name = "W likwidacji" },
                new CompanyStatus { CompanyStatusId = 8, Name = "Wykreślona z wykazu" },
                new CompanyStatus { CompanyStatusId = 3, Name = "Zlikwidowana" },

                //(niżej wymienione) W ramach REGON
                new CompanyStatus { CompanyStatusId = 11, Name = "Zawieszona" },
                new CompanyStatus { CompanyStatusId = 12, Name = "Wznowiona" },
                new CompanyStatus { CompanyStatusId = 13, Name = "Zakończona" },
            };
            builder.HasData(data);
        }
    }
}
