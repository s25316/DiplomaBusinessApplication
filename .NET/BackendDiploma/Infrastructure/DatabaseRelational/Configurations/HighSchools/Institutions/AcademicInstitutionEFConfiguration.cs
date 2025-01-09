using Application.DatabaseRelational.Models.Companies;
using Application.DatabaseRelational.Models.HighSchools.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.HighSchools.Institutions
{
    public class AcademicInstitutionEFConfiguration : IEntityTypeConfiguration<AcademicInstitution>
    {
        public void Configure(EntityTypeBuilder<AcademicInstitution> builder)
        {
            builder.ToTable(nameof(AcademicInstitution));
            builder.HasKey(x => x.Id).HasName($"{nameof(AcademicInstitution)}_pk");

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasDefaultValueSql("(newid())");
            builder.Property(x => x.LastUpdate)
                .HasDefaultValueSql("(GETDATE())");

            builder.HasOne(x => x.Company)
                .WithOne(x => x.AcademicInstitution)
                .HasForeignKey<AcademicInstitution>(x => x.Id)
                .HasConstraintName($"{nameof(Company)}_{nameof(AcademicInstitution)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
