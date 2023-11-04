using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TAREAS_AGAMVC.Models;

public partial class BddtareasagaContext : DbContext
{
    public BddtareasagaContext()
    {
    }

    public BddtareasagaContext(DbContextOptions<BddtareasagaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Colaborador> Colaboradors { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCat).HasName("PK__Categori__D54686DE073D60C2");

            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.NombreCat)
                .HasMaxLength(100)
                .HasColumnName("nombre_cat");
        });

        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.IdCol).HasName("PK__Colabora__D69671708A0F9FEE");

            entity.ToTable("Colaborador");

            entity.Property(e => e.IdCol).HasColumnName("id_col");
            entity.Property(e => e.AMaternoCol)
                .HasMaxLength(100)
                .HasColumnName("aMaterno_col");
            entity.Property(e => e.APaternoCol)
                .HasMaxLength(100)
                .HasColumnName("aPaterno_col");
            entity.Property(e => e.NombreCol)
                .HasMaxLength(100)
                .HasColumnName("nombre_col");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTar).HasName("PK__Tarea__6A2987FCF020B6F8");

            entity.ToTable("Tarea");

            entity.Property(e => e.IdTar).HasColumnName("id_tar");
            entity.Property(e => e.DescripcionTar)
                .HasMaxLength(100)
                .HasColumnName("descripcion_tar");
            entity.Property(e => e.EstatusTar)
                .HasMaxLength(100)
                .HasColumnName("estatus_tar");
            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.IdCol).HasColumnName("id_col");
            entity.Property(e => e.NombreTar)
                .HasMaxLength(100)
                .HasColumnName("nombre_tar");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_categoria");

            entity.HasOne(d => d.IdColNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdCol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_colaborador");




        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
