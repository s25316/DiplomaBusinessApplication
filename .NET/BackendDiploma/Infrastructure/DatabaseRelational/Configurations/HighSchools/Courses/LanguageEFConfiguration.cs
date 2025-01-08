using Application.DatabaseRelational.Models.HighSchools.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Courses
{
    internal class LanguageEFConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable(nameof(Language));
            builder.HasKey(x => x.Code).HasName($"{nameof(Language)}_pk");

            builder.Property(x => x.Code).HasMaxLength(20);
            builder.Property(x => x.Name).HasMaxLength(100);

            //1-*
            builder.HasMany(x => x.CourseLanguage)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.LanguageCode)
                .HasConstraintName($"{nameof(Course)}_{nameof(Language)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CourseLanguages)
                .WithMany(x => x.Languages)
                .UsingEntity<Dictionary<string, object>>(
                    $"{nameof(Course)}{nameof(Language)}",
                    r => r.HasOne<Course>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Course)}Id")
                    .HasConstraintName($"{nameof(Course)}{nameof(Language)}_{nameof(Course)}")
                    .OnDelete(DeleteBehavior.Cascade),
                    l => l.HasOne<Language>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Language)}Id")
                    .HasConstraintName($"{nameof(Course)}{nameof(Language)}_{nameof(Language)}")
                    .OnDelete(DeleteBehavior.Cascade)
                );
            Language[] items =
            {
                new Language { Code = "alb-sqi", Name = "albański" },
                new Language { Code = "eng", Name = "angielski" },
                new Language { Code = "ara", Name = "arabski" },
                new Language { Code = "bel", Name = "białoruski" },
                new Language { Code = "bul", Name = "bułgarski" },
                new Language { Code = "cel", Name = "celtyckie" },
                new Language { Code = "chi-zho", Name = "chiński" },
                new Language { Code = "scr-hrv", Name = "chorwacki" },
                new Language { Code = "cze-ces", Name = "czeski" },
                new Language { Code = "dan", Name = "duński" },
                new Language { Code = "fin", Name = "fiński" },
                new Language { Code = "fre-fra", Name = "francuski" },
                new Language { Code = "gem", Name = "germańskie" },
                new Language { Code = "gre-ell", Name = "grecki" },
                new Language { Code = "heb", Name = "hebrajski" },
                new Language { Code = "hin", Name = "hindi" },
                new Language { Code = "spa", Name = "hiszpański" },
                new Language { Code = "dut-nld", Name = "holenderski" },
                new Language { Code = "ind", Name = "indonezyjski" },
                new Language { Code = "opi-ij", Name = "inny język" },
                new Language { Code = "ice-isl", Name = "islandzki" },
                new Language { Code = "jpn", Name = "japoński" },
                new Language { Code = "yid", Name = "jidysz" },
                new Language { Code = "cat", Name = "kataloński" },
                new Language { Code = "kor", Name = "koreański" },
                new Language { Code = "lit", Name = "litewski" },
                new Language { Code = "lat", Name = "łacina" },
                new Language { Code = "lav", Name = "łotewski" },
                new Language { Code = "mac-mkd", Name = "macedoński" },
                new Language { Code = "may-msa", Name = "malajski" },
                new Language { Code = "nno", Name = "neonorweski (nynorsk)" },
                new Language { Code = "ger-deu", Name = "niemiecki" },
                new Language { Code = "nor", Name = "norweski" },
                new Language { Code = "nob", Name = "norweski tradycyjny (bokmal)" },
                new Language { Code = "per-fas", Name = "perski (farsi)" },
                new Language { Code = "pol", Name = "polski" },
                new Language { Code = "pso", Name = "polski język migowy" },
                new Language { Code = "por", Name = "portugalski" },
                new Language { Code = "rus", Name = "rosyjski" },
                new Language { Code = "rum-ron", Name = "rumuński" },
                new Language { Code = "scc-srp", Name = "serbski" },
                new Language { Code = "slo-slk", Name = "słowacki" },
                new Language { Code = "slv", Name = "słoweński" },
                new Language { Code = "swe", Name = "szwedzki" },
                new Language { Code = "tur", Name = "turecki" },
                new Language { Code = "ukr", Name = "ukraiński" },
                new Language { Code = "urd", Name = "urdu" },
                new Language { Code = "hun", Name = "węgierski" },
                new Language { Code = "vie", Name = "wietnamski" },
                new Language { Code = "ita", Name = "włoski" }
            };
            builder.HasData(items);
        }
    }
}
