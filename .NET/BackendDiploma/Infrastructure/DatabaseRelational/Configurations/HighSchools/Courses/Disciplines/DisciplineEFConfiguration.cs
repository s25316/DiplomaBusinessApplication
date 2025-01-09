using Application.DatabaseRelational.Models.HighSchools.Courses.Disciplines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses.Disciplines
{
    public class DisciplineEFConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(nameof(Discipline));
            builder.HasKey(x => x.DisciplineCode).HasName($"{nameof(Discipline)}_pk");

            builder.Property(x => x.DisciplineCode).HasMaxLength(20);
            builder.Property(x => x.Name).HasMaxLength(100);

            Discipline[] items =
            {
                new Discipline { DisciplineCode = "DS010101N", Name = "archeologia" },
                new Discipline { DisciplineCode = "DS010201N", Name = "architektura i urbanistyka" },
                new Discipline { DisciplineCode = "DS010607N", Name = "astronomia" },
                new Discipline { DisciplineCode = "DS010213N", Name = "automatyka, elektronika, elektrotechnika i technologie kosmiczne" },
                new Discipline { DisciplineCode = "DS010305N", Name = "biologia medyczna" },
                new Discipline { DisciplineCode = "DS010608N", Name = "biotechnologia" },
                new Discipline { DisciplineCode = "DS010501N", Name = "ekonomia i finanse" },
                new Discipline { DisciplineCode = "DS010108N", Name = "etnologia i antropologia kulturowa" },
                new Discipline { DisciplineCode = "DS010102N", Name = "filozofia" },
                new Discipline { DisciplineCode = "DS010502N", Name = "geografia społeczno-ekonomiczna i gospodarka przestrzenna" },
                new Discipline { DisciplineCode = "DS010103N", Name = "historia" },
                new Discipline { DisciplineCode = "DS010601N", Name = "informatyka" },
                new Discipline { DisciplineCode = "DS010204N", Name = "informatyka techniczna i telekomunikacja" },
                new Discipline { DisciplineCode = "DS010210N", Name = "inżynieria bezpieczeństwa" },
                new Discipline { DisciplineCode = "DS010202N", Name = "inżynieria biomedyczna" },
                new Discipline { DisciplineCode = "DS010205N", Name = "inżynieria chemiczna" },
                new Discipline { DisciplineCode = "DS010212N", Name = "inżynieria lądowa, geodezja i transport" },
                new Discipline { DisciplineCode = "DS010207N", Name = "inżynieria materiałowa" },
                new Discipline { DisciplineCode = "DS010208N", Name = "inżynieria mechaniczna" },
                new Discipline { DisciplineCode = "DS010209N", Name = "inżynieria środowiska, górnictwo i energetyka" },
                new Discipline { DisciplineCode = "DS010104N", Name = "językoznawstwo" },
                new Discipline { DisciplineCode = "DS010105N", Name = "literaturoznawstwo" },
                new Discipline { DisciplineCode = "DS010602N", Name = "matematyka" },
                new Discipline { DisciplineCode = "DS010702N", Name = "nauki biblijne" },
                new Discipline { DisciplineCode = "DS010603N", Name = "nauki biologiczne" },
                new Discipline { DisciplineCode = "DS010604N", Name = "nauki chemiczne" },
                new Discipline { DisciplineCode = "DS010301N", Name = "nauki farmaceutyczne" },
                new Discipline { DisciplineCode = "DS010605N", Name = "nauki fizyczne" },
                new Discipline { DisciplineCode = "DS010405N", Name = "nauki leśne" },
                new Discipline { DisciplineCode = "DS010304N", Name = "nauki medyczne" },
                new Discipline { DisciplineCode = "DS010503N", Name = "nauki o bezpieczeństwie" },
                new Discipline { DisciplineCode = "DS010504N", Name = "nauki o komunikacji społecznej i mediach" },
                new Discipline { DisciplineCode = "DS010302N", Name = "nauki o kulturze fizycznej" },
                new Discipline { DisciplineCode = "DS010106N", Name = "nauki o kulturze i religii" },
                new Discipline { DisciplineCode = "DS010505N", Name = "nauki o polityce i administracji" },
                new Discipline { DisciplineCode = "DS010901N", Name = "nauki o rodzinie" },
                new Discipline { DisciplineCode = "DS010107N", Name = "nauki o sztuce" },
                new Discipline { DisciplineCode = "DS010506N", Name = "nauki o zarządzaniu i jakości" },
                new Discipline { DisciplineCode = "DS010303N", Name = "nauki o zdrowiu" },
                new Discipline { DisciplineCode = "DS010606N", Name = "nauki o Ziemi i środowisku" },
                new Discipline { DisciplineCode = "DS010507N", Name = "nauki prawne" },
                new Discipline { DisciplineCode = "DS010508N", Name = "nauki socjologiczne" },
                new Discipline { DisciplineCode = "DS010701N", Name = "nauki teologiczne" },
                new Discipline { DisciplineCode = "DS010211N", Name = "ochrona dziedzictwa i konserwacja zabytków" },
                new Discipline { DisciplineCode = "DS010509N", Name = "pedagogika" },
                new Discipline { DisciplineCode = "DS010109N", Name = "polonistyka" },
                new Discipline { DisciplineCode = "DS010510N", Name = "prawo kanoniczne" },
                new Discipline { DisciplineCode = "DS010511N", Name = "psychologia" },
                new Discipline { DisciplineCode = "DS010401N", Name = "rolnictwo i ogrodnictwo" },
                new Discipline { DisciplineCode = "DS010512N", Name = "stosunki międzynarodowe" },
                new Discipline { DisciplineCode = "DS010801N", Name = "sztuki filmowe i teatralne" },
                new Discipline { DisciplineCode = "DS010802N", Name = "sztuki muzyczne" },
                new Discipline { DisciplineCode = "DS010803N", Name = "sztuki plastyczne i konserwacja dzieł sztuki" },
                new Discipline { DisciplineCode = "DS010402N", Name = "technologia żywności i żywienia" },
                new Discipline { DisciplineCode = "DS011001N", Name = "weterynaria" },
                new Discipline { DisciplineCode = "DS010404N", Name = "zootechnika i rybactwo" }
            };

            builder.HasData(items);
        }
    }
}
