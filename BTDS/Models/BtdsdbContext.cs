using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Models;

public partial class BtdsdbContext : DbContext
{
    public BtdsdbContext()
    {
    }

    public BtdsdbContext(DbContextOptions<BtdsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SACHIN\\SQLEXPRESS;Database=BTDSDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cards__3214EC07604A62B5");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LearningTopics)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Learning_topics");
            entity.Property(e => e.StageId).HasColumnName("Stage_Id");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Task_title");
            entity.Property(e => e.TechStack)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Tech_stack");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Stage).WithMany(p => p.Cards)
                .HasForeignKey(d => d.StageId)
                .HasConstraintName("fk_StageId");
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stages__3214EC070117A4C8");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
