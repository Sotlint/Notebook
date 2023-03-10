using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Notebook;

public partial class NbContext : DbContext
{
    public NbContext()
    {
    }

    public NbContext(DbContextOptions<NbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressDatum> AddressData { get; set; }

    public virtual DbSet<BirthdayDatum> BirthdayData { get; set; }

    public virtual DbSet<Congratulation> Congratulations { get; set; }

    public virtual DbSet<ContactDatum> ContactData { get; set; }

    public virtual DbSet<Fiodatum> Fiodata { get; set; }

    public virtual DbSet<RelationshipsDatum> RelationshipsData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=DB\\NB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressDatum>(entity =>
        {
            entity.HasKey(e => e.AdId);

            entity.HasIndex(e => e.AdId, "IX_AddressData_AD_ID").IsUnique();

            entity.Property(e => e.AdId)
                .ValueGeneratedNever()
                .HasColumnName("AD_ID");
            entity.Property(e => e.FioId).HasColumnName("FIO_ID");

            entity.HasOne(d => d.Fio).WithMany(p => p.AddressData)
                .HasForeignKey(d => d.FioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<BirthdayDatum>(entity =>
        {
            entity.HasKey(e => e.BdId);

            entity.HasIndex(e => e.BdId, "IX_BirthdayData_BD_ID").IsUnique();

            entity.Property(e => e.BdId)
                .ValueGeneratedNever()
                .HasColumnName("BD_ID");
            entity.Property(e => e.FioId).HasColumnName("FIO_ID");

            entity.HasOne(d => d.Fio).WithMany(p => p.BirthdayData)
                .HasForeignKey(d => d.FioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Congratulation>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.HasIndex(e => e.CId, "IX_Congratulations_C_ID").IsUnique();

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasColumnName("C_ID");
            entity.Property(e => e.FioId).HasColumnName("FIO_ID");
            entity.Property(e => e.Text).HasColumnName("TEXT");

            entity.HasOne(d => d.Fio).WithMany(p => p.Congratulations)
                .HasForeignKey(d => d.FioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ContactDatum>(entity =>
        {
            entity.HasKey(e => e.CdId);

            entity.HasIndex(e => e.CdId, "IX_ContactData_CD_ID").IsUnique();

            entity.HasIndex(e => e.Mail, "IX_ContactData_Mail").IsUnique();

            entity.HasIndex(e => e.Telephone, "IX_ContactData_Telephone").IsUnique();

            entity.Property(e => e.CdId)
                .ValueGeneratedNever()
                .HasColumnName("CD_ID");
            entity.Property(e => e.FioId).HasColumnName("FIO_ID");

            entity.HasOne(d => d.Fio).WithMany(p => p.ContactData)
                .HasForeignKey(d => d.FioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Fiodatum>(entity =>
        {
            entity.HasKey(e => e.FioId);

            entity.ToTable("FIOData");

            entity.HasIndex(e => e.FioId, "IX_FIOData_FIO_ID").IsUnique();

            entity.Property(e => e.FioId)
                .ValueGeneratedNever()
                .HasColumnName("FIO_ID");
        });

        modelBuilder.Entity<RelationshipsDatum>(entity =>
        {
            entity.HasKey(e => e.RdId);

            entity.HasIndex(e => e.RdId, "IX_RelationshipsData_RD_ID").IsUnique();

            entity.Property(e => e.RdId)
                .ValueGeneratedNever()
                .HasColumnName("RD_ID");
            entity.Property(e => e.FioId).HasColumnName("FIO_ID");

            entity.HasOne(d => d.Fio).WithMany(p => p.RelationshipsData)
                .HasForeignKey(d => d.FioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
