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
            builder.HasKey(x => x.LanguageCode).HasName($"{nameof(Language)}_pk");

            builder.Property(x => x.LanguageCode).HasMaxLength(20);
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
                    .HasForeignKey($"{nameof(Course)}AcademicInstitutionId")
                    .HasConstraintName($"{nameof(Course)}{nameof(Language)}_{nameof(Course)}")
                    .OnDelete(DeleteBehavior.Cascade),
                    l => l.HasOne<Language>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Language)}AcademicInstitutionId")
                    .HasConstraintName($"{nameof(Course)}{nameof(Language)}_{nameof(Language)}")
                    .OnDelete(DeleteBehavior.Cascade)
                );
            Language[] items =
            {
                new Language { LanguageCode = "alb-sqi", Name = "albański" },
                new Language { LanguageCode = "eng", Name = "angielski" },
                new Language { LanguageCode = "ara", Name = "arabski" },
                new Language { LanguageCode = "bel", Name = "białoruski" },
                new Language { LanguageCode = "bul", Name = "bułgarski" },
                new Language { LanguageCode = "cel", Name = "celtyckie" },
                new Language { LanguageCode = "chi-zho", Name = "chiński" },
                new Language { LanguageCode = "scr-hrv", Name = "chorwacki" },
                new Language { LanguageCode = "cze-ces", Name = "czeski" },
                new Language { LanguageCode = "dan", Name = "duński" },
                new Language { LanguageCode = "fin", Name = "fiński" },
                new Language { LanguageCode = "fre-fra", Name = "francuski" },
                new Language { LanguageCode = "gem", Name = "germańskie" },
                new Language { LanguageCode = "gre-ell", Name = "grecki" },
                new Language { LanguageCode = "heb", Name = "hebrajski" },
                new Language { LanguageCode = "hin", Name = "hindi" },
                new Language { LanguageCode = "spa", Name = "hiszpański" },
                new Language { LanguageCode = "dut-nld", Name = "holenderski" },
                new Language { LanguageCode = "ind", Name = "indonezyjski" },
                new Language { LanguageCode = "opi-ij", Name = "inny język" },
                new Language { LanguageCode = "ice-isl", Name = "islandzki" },
                new Language { LanguageCode = "jpn", Name = "japoński" },
                new Language { LanguageCode = "yid", Name = "jidysz" },
                new Language { LanguageCode = "cat", Name = "kataloński" },
                new Language { LanguageCode = "kor", Name = "koreański" },
                new Language { LanguageCode = "lit", Name = "litewski" },
                new Language { LanguageCode = "lat", Name = "łacina" },
                new Language { LanguageCode = "lav", Name = "łotewski" },
                new Language { LanguageCode = "mac-mkd", Name = "macedoński" },
                new Language { LanguageCode = "may-msa", Name = "malajski" },
                new Language { LanguageCode = "nno", Name = "neonorweski (nynorsk)" },
                new Language { LanguageCode = "ger-deu", Name = "niemiecki" },
                new Language { LanguageCode = "nor", Name = "norweski" },
                new Language { LanguageCode = "nob", Name = "norweski tradycyjny (bokmal)" },
                new Language { LanguageCode = "per-fas", Name = "perski (farsi)" },
                new Language { LanguageCode = "pol", Name = "polski" },
                new Language { LanguageCode = "pso", Name = "polski język migowy" },
                new Language { LanguageCode = "por", Name = "portugalski" },
                new Language { LanguageCode = "rus", Name = "rosyjski" },
                new Language { LanguageCode = "rum-ron", Name = "rumuński" },
                new Language { LanguageCode = "scc-srp", Name = "serbski" },
                new Language { LanguageCode = "slo-slk", Name = "słowacki" },
                new Language { LanguageCode = "slv", Name = "słoweński" },
                new Language { LanguageCode = "swe", Name = "szwedzki" },
                new Language { LanguageCode = "tur", Name = "turecki" },
                new Language { LanguageCode = "ukr", Name = "ukraiński" },
                new Language { LanguageCode = "urd", Name = "urdu" },
                new Language { LanguageCode = "hun", Name = "węgierski" },
                new Language { LanguageCode = "vie", Name = "wietnamski" },
                new Language { LanguageCode = "ita", Name = "włoski" }
            };
            builder.HasData(items);
        }
    }
}
