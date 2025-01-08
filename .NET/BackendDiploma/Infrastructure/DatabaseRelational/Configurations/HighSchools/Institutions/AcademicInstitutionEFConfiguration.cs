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
            builder.Property(x => x.Name)
                .HasMaxLength(800);
            builder.Property(x => x.WWW)
                .HasMaxLength(100);
            builder.Property(x => x.Email)
                .HasMaxLength(100);
            builder.Property(x => x.Phone)
                .HasMaxLength(100);
            builder.Property(x => x.LastUpdate)
                .HasDefaultValueSql("(GETDATE())");

            builder.HasOne(x => x.ParentInstitution)
                .WithMany(x => x.ChildInstitutions)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName($"{nameof(AcademicInstitution)}_{nameof(AcademicInstitution)}");

        }
    }
}
