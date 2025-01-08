using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class Diploma2Context : DbContext
{
    public Diploma2Context()
    {
    }

    public Diploma2Context(DbContextOptions<Diploma2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicInstitution> AcademicInstitutions { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AinameHistory> AinameHistories { get; set; }

    public virtual DbSet<AispecificType> AispecificTypes { get; set; }

    public virtual DbSet<AispecificTypeHistory> AispecificTypeHistories { get; set; }

    public virtual DbSet<Aistatus> Aistatuses { get; set; }

    public virtual DbSet<AistatusHistory> AistatusHistories { get; set; }

    public virtual DbSet<Aitype> Aitypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<DivisionType> DivisionTypes { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Diploma2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicInstitution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AcademicInstitution_pk");

            entity.ToTable("AcademicInstitution");

            entity.HasIndex(e => e.ParentId, "IX_AcademicInstitution_ParentId");

            entity.HasIndex(e => e.TypeId, "IX_AcademicInstitution_TypeId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LiquidationDate).HasColumnName("liquidationDate");
            entity.Property(e => e.Name).HasMaxLength(800);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.Www)
                .HasMaxLength(100)
                .HasColumnName("WWW");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("AcademicInstitution_AcademicInstitution");

            entity.HasOne(d => d.Type).WithMany(p => p.AcademicInstitutions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AIType_AcademicInstitution");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("Address_pk");

            entity.ToTable("Address");

            entity.HasIndex(e => e.DivisionId, "IX_Address_DivisionId");

            entity.HasIndex(e => e.StreetId, "IX_Address_StreetId");

            entity.Property(e => e.AddressId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApartmentNumber).HasMaxLength(50);
            entity.Property(e => e.BuildingNumber).HasMaxLength(50);

            entity.HasOne(d => d.Division).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_Division");

            entity.HasOne(d => d.Street).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("Address_Street");
        });

        modelBuilder.Entity<AinameHistory>(entity =>
        {
            entity.HasKey(e => new { e.InstitutionId, e.Date }).HasName("AINameHistory_pk");

            entity.ToTable("AINameHistory");

            entity.Property(e => e.Name).HasMaxLength(800);

            entity.HasOne(d => d.Institution).WithMany(p => p.AinameHistories)
                .HasForeignKey(d => d.InstitutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AINameHistory_AcademicInstitution");
        });

        modelBuilder.Entity<AispecificType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AISpecificType_pk");

            entity.ToTable("AISpecificType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<AispecificTypeHistory>(entity =>
        {
            entity.HasKey(e => new { e.InstitutionId, e.TypeId, e.Date }).HasName("AISpecificTypeHistory_pk");

            entity.ToTable("AISpecificTypeHistory");

            entity.HasIndex(e => e.TypeId, "IX_AISpecificTypeHistory_TypeId");

            entity.HasOne(d => d.Institution).WithMany(p => p.AispecificTypeHistories)
                .HasForeignKey(d => d.InstitutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AISpecificTypeHistory_AcademicInstitution");

            entity.HasOne(d => d.Type).WithMany(p => p.AispecificTypeHistories)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AISpecificTypeHistory_AISpecificType");
        });

        modelBuilder.Entity<Aistatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AIStatus_pk");

            entity.ToTable("AIStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<AistatusHistory>(entity =>
        {
            entity.HasKey(e => new { e.InstitutionId, e.StatusId, e.Date }).HasName("AIStatusHistory_pk");

            entity.ToTable("AIStatusHistory");

            entity.HasIndex(e => e.StatusId, "IX_AIStatusHistory_StatusId");

            entity.HasOne(d => d.Institution).WithMany(p => p.AistatusHistories)
                .HasForeignKey(d => d.InstitutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AIStatusHistory_AcademicInstitution");

            entity.HasOne(d => d.Status).WithMany(p => p.AistatusHistories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AIStatusHistory_AIStatus");
        });

        modelBuilder.Entity<Aitype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AIType_pk");

            entity.ToTable("AIType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("Country_pk");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("Division_pk");

            entity.ToTable("Division", tb => tb.HasTrigger("CREATE_Division_Paths"));

            entity.HasIndex(e => e.CountryId, "IX_Division_CountryId");

            entity.HasIndex(e => e.DivisionTypeId, "IX_Division_DivisionTypeId");

            entity.HasIndex(e => e.ParentDivisionId, "IX_Division_ParentDivisionId");

            entity.Property(e => e.DivisionId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ParentsPath).HasMaxLength(800);

            entity.HasOne(d => d.Country).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Country_Division");

            entity.HasOne(d => d.DivisionType).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.DivisionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DivisionType_Division");

            entity.HasOne(d => d.ParentDivision).WithMany(p => p.InverseParentDivision)
                .HasForeignKey(d => d.ParentDivisionId)
                .HasConstraintName("Division_Division");

            entity.HasMany(d => d.Streets).WithMany(p => p.Divisions)
                .UsingEntity<Dictionary<string, object>>(
                    "DivisionStreet",
                    r => r.HasOne<Street>().WithMany()
                        .HasForeignKey("StreetId")
                        .HasConstraintName("FK_DivisionStreet_StreetId"),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("DivisionId")
                        .HasConstraintName("FK_DivisionStreet_DivisionId"),
                    j =>
                    {
                        j.HasKey("DivisionId", "StreetId");
                        j.ToTable("DivisionStreet");
                        j.HasIndex(new[] { "StreetId" }, "IX_DivisionStreet_StreetId");
                    });
        });

        modelBuilder.Entity<DivisionType>(entity =>
        {
            entity.HasKey(e => e.DivisionTypeId).HasName("DivisionType_pk");

            entity.ToTable("DivisionType");

            entity.Property(e => e.DivisionTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("Street_pk");

            entity.ToTable("Street");

            entity.HasIndex(e => e.CountryId, "IX_Street_CountryId");

            entity.HasIndex(e => e.DivisionTypeId, "IX_Street_DivisionTypeId");

            entity.Property(e => e.StreetId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Streets)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Country_Street");

            entity.HasOne(d => d.DivisionType).WithMany(p => p.Streets)
                .HasForeignKey(d => d.DivisionTypeId)
                .HasConstraintName("DivisionType_Street");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
