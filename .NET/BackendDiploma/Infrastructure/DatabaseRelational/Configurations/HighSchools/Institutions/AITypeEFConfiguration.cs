using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AITypeEFConfiguration : IEntityTypeConfiguration<AIType>
    {
        public void Configure(EntityTypeBuilder<AIType> builder)
        {
            builder.ToTable(nameof(AIType));
            builder.HasKey(x => x.AcademicInstitutionTypeId).HasName($"{nameof(AIType)}_pk");

            builder.Property(x => x.AcademicInstitutionTypeId).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.IsSchool).HasDefaultValue((false));

            builder.HasMany(x => x.AcademicInstitutions)
                .WithOne(x => x.AcademicInstitutionType)
                .HasForeignKey(x => x.AcademicInstitutionTypeId)
                .HasConstraintName($"{nameof(AIType)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);

            //https://radon.nauka.gov.pl/opendata/polon/dictionaries/institution/institutionKinds
            AIType[] data =
                {
                new AIType {AcademicInstitutionTypeId =16 , IsSchool= false, Name ="Federacja" },
                new AIType {AcademicInstitutionTypeId =5 , IsSchool= false, Name ="Instytucja naukowa" },
                new AIType {AcademicInstitutionTypeId =1 , IsSchool= true, Name ="Uczelnia kościelna" },
                new AIType {AcademicInstitutionTypeId =10 , IsSchool= true, Name ="Uczelnia niepubliczna" },
                new AIType {AcademicInstitutionTypeId =13 , IsSchool= true, Name ="Uczelnia publiczna" },
            };
            builder.HasData(data);
        }
    }
}
