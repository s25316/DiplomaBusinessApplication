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
            builder.HasKey(x => x.Id).HasName($"{nameof(AIType)}_pk");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.IsSchool).HasDefaultValue((false));

            builder.HasMany(x => x.Institutions)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .HasConstraintName($"{nameof(AIType)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);

            //https://radon.nauka.gov.pl/opendata/polon/dictionaries/institution/institutionKinds
            AIType[] data =
                {
                new AIType {Id =16 , IsSchool= false, Name ="Federacja" },
                new AIType {Id =5 , IsSchool= false, Name ="Instytucja naukowa" },
                new AIType {Id =1 , IsSchool= true, Name ="Uczelnia kościelna" },
                new AIType {Id =10 , IsSchool= true, Name ="Uczelnia niepubliczna" },
                new AIType {Id =13 , IsSchool= true, Name ="Uczelnia publiczna" },
            };
            builder.HasData(data);
        }
    }
}
