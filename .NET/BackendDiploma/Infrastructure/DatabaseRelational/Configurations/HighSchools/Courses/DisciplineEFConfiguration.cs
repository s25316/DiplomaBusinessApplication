using Application.DatabaseRelational.Models.HighSchools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    public class DisciplineEFConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(nameof(Discipline));
            builder.HasKey(x => x.Code).HasName($"{nameof(Discipline)}_pk");

            builder.Property(x => x.Code).HasMaxLength(20);
            builder.Property(x => x.Name).HasMaxLength(100);

            Discipline[] items =
            {
                new Discipline { Code = "DS010101N", Name = "archeologia" },
                new Discipline { Code = "DS010201N", Name = "architektura i urbanistyka" },
                new Discipline { Code = "DS010607N", Name = "astronomia" },
                new Discipline { Code = "DS010213N", Name = "automatyka, elektronika, elektrotechnika i technologie kosmiczne" },
                new Discipline { Code = "DS010305N", Name = "biologia medyczna" },
                new Discipline { Code = "DS010608N", Name = "biotechnologia" },
                new Discipline { Code = "DS010501N", Name = "ekonomia i finanse" },
                new Discipline { Code = "DS010108N", Name = "etnologia i antropologia kulturowa" },
                new Discipline { Code = "DS010102N", Name = "filozofia" },
                new Discipline { Code = "DS010502N", Name = "geografia społeczno-ekonomiczna i gospodarka przestrzenna" },
                new Discipline { Code = "DS010103N", Name = "historia" },
                new Discipline { Code = "DS010601N", Name = "informatyka" },
                new Discipline { Code = "DS010204N", Name = "informatyka techniczna i telekomunikacja" },
                new Discipline { Code = "DS010210N", Name = "inżynieria bezpieczeństwa" },
                new Discipline { Code = "DS010202N", Name = "inżynieria biomedyczna" },
                new Discipline { Code = "DS010205N", Name = "inżynieria chemiczna" },
                new Discipline { Code = "DS010212N", Name = "inżynieria lądowa, geodezja i transport" },
                new Discipline { Code = "DS010207N", Name = "inżynieria materiałowa" },
                new Discipline { Code = "DS010208N", Name = "inżynieria mechaniczna" },
                new Discipline { Code = "DS010209N", Name = "inżynieria środowiska, górnictwo i energetyka" },
                new Discipline { Code = "DS010104N", Name = "językoznawstwo" },
                new Discipline { Code = "DS010105N", Name = "literaturoznawstwo" },
                new Discipline { Code = "DS010602N", Name = "matematyka" },
                new Discipline { Code = "DS010702N", Name = "nauki biblijne" },
                new Discipline { Code = "DS010603N", Name = "nauki biologiczne" },
                new Discipline { Code = "DS010604N", Name = "nauki chemiczne" },
                new Discipline { Code = "DS010301N", Name = "nauki farmaceutyczne" },
                new Discipline { Code = "DS010605N", Name = "nauki fizyczne" },
                new Discipline { Code = "DS010405N", Name = "nauki leśne" },
                new Discipline { Code = "DS010304N", Name = "nauki medyczne" },
                new Discipline { Code = "DS010503N", Name = "nauki o bezpieczeństwie" },
                new Discipline { Code = "DS010504N", Name = "nauki o komunikacji społecznej i mediach" },
                new Discipline { Code = "DS010302N", Name = "nauki o kulturze fizycznej" },
                new Discipline { Code = "DS010106N", Name = "nauki o kulturze i religii" },
                new Discipline { Code = "DS010505N", Name = "nauki o polityce i administracji" },
                new Discipline { Code = "DS010901N", Name = "nauki o rodzinie" },
                new Discipline { Code = "DS010107N", Name = "nauki o sztuce" },
                new Discipline { Code = "DS010506N", Name = "nauki o zarządzaniu i jakości" },
                new Discipline { Code = "DS010303N", Name = "nauki o zdrowiu" },
                new Discipline { Code = "DS010606N", Name = "nauki o Ziemi i środowisku" },
                new Discipline { Code = "DS010507N", Name = "nauki prawne" },
                new Discipline { Code = "DS010508N", Name = "nauki socjologiczne" },
                new Discipline { Code = "DS010701N", Name = "nauki teologiczne" },
                new Discipline { Code = "DS010211N", Name = "ochrona dziedzictwa i konserwacja zabytków" },
                new Discipline { Code = "DS010509N", Name = "pedagogika" },
                new Discipline { Code = "DS010109N", Name = "polonistyka" },
                new Discipline { Code = "DS010510N", Name = "prawo kanoniczne" },
                new Discipline { Code = "DS010511N", Name = "psychologia" },
                new Discipline { Code = "DS010401N", Name = "rolnictwo i ogrodnictwo" },
                new Discipline { Code = "DS010512N", Name = "stosunki międzynarodowe" },
                new Discipline { Code = "DS010801N", Name = "sztuki filmowe i teatralne" },
                new Discipline { Code = "DS010802N", Name = "sztuki muzyczne" },
                new Discipline { Code = "DS010803N", Name = "sztuki plastyczne i konserwacja dzieł sztuki" },
                new Discipline { Code = "DS010402N", Name = "technologia żywności i żywienia" },
                new Discipline { Code = "DS011001N", Name = "weterynaria" },
                new Discipline { Code = "DS010404N", Name = "zootechnika i rybactwo" }
            };

            builder.HasData(items);
        }
    }
}
