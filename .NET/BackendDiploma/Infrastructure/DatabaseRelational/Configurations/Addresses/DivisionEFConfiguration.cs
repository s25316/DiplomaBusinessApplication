using Application.DatabaseRelational.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseRelational.Configurations.Addresses
{
    public class DivisionEFConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable(nameof(Division));
            builder.HasKey(x => x.DivisionId).HasName($"{nameof(Division)}_pk");

            builder.Property(x => x.DivisionId).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Level).HasDefaultValue(0);
            builder.Property(x => x.ParentsPath).HasMaxLength(800);

            builder.HasMany(x => x.Streets)
                .WithMany(x => x.Divisions)
                .UsingEntity<Dictionary<string, object>>(
                    $"{nameof(Division)}{nameof(Street)}",
                    l => l.HasOne<Street>()
                        .WithMany()
                        .HasForeignKey($"{nameof(Street)}Id")
                        .HasConstraintName($"FK_{nameof(Division)}{nameof(Street)}_{nameof(Street)}Id")
                        .OnDelete(DeleteBehavior.Cascade),
                    r => r.HasOne<Division>()
                        .WithMany()
                        .HasForeignKey($"{nameof(Division)}Id")
                        .HasConstraintName($"FK_{nameof(Division)}{nameof(Street)}_{nameof(Division)}Id")
                        .OnDelete(DeleteBehavior.Cascade)
            );

            builder.HasOne(x => x.ParentDivision)
                .WithMany(x => x.ChildDivisions)
                .HasForeignKey(x => x.ParentDivisionId)
                .HasConstraintName($"{nameof(Division)}_{nameof(Division)}");
        }
    }
}
