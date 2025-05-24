using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _1.DAL.DataContext;

public partial class MakersDbContext : DbContext
{
    public MakersDbContext()
    {
    }

    public MakersDbContext(DbContextOptions<MakersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EstadosPrestamo> EstadosPrestamos { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstadosPrestamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadosP__3214EC079501E96F");

            entity.ToTable("EstadosPrestamo");

            entity.HasIndex(e => e.Nombre, "UQ__EstadosP__75E3EFCFE13B55E7").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prestamo__3214EC07E6AEF620");

            entity.Property(e => e.EstadoPrestamoId).HasDefaultValue(1);
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MotivoRechazo).HasMaxLength(500);

            entity.HasOne(d => d.EstadoPrestamo).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.EstadoPrestamoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamos__Estad__44FF419A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamos__Usuar__440B1D61");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC072CEA304D");

            entity.HasIndex(e => e.Nombre, "UQ__Roles__75E3EFCFDE7B1DC6").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07C26D483C");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105344F4E3130").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__RolId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
