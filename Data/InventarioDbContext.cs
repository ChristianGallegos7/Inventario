using System;
using System.Collections.Generic;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Data;

public partial class InventarioDbContext : DbContext
{
    public InventarioDbContext()
    {
    }

    public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permisos> Permisos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Rolpermiso> Rolpermiso { get; set; }

    public virtual DbSet<Usuariorol> Usuariorol { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=aliengnss;Username=aliengnss;Password=aliengnss.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permisos>(entity =>
        {
            entity.HasKey(e => e.Idpermiso).HasName("pk_permisos");

            entity.ToTable("permisos");

            entity.Property(e => e.Idpermiso)
                .ValueGeneratedNever()
                .HasColumnName("idpermiso");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(100)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechaactualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("pk_roles");

            entity.ToTable("roles");

            entity.Property(e => e.Idrol)
                .ValueGeneratedNever()
                .HasColumnName("idrol");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechaactualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Rolpermiso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rolpermiso");

            entity.HasIndex(e => new { e.Idrol, e.Idpermiso }, "ak_key_1_rolpermi").IsUnique();

            entity.Property(e => e.Idpermiso).HasColumnName("idpermiso");
            entity.Property(e => e.Idrol).HasColumnName("idrol");

            entity.HasOne(d => d.IdpermisoNavigation).WithMany()
                .HasForeignKey(d => d.Idpermiso)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_rolpermi_reference_permisos");

            entity.HasOne(d => d.IdrolNavigation).WithMany()
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_rolpermi_reference_roles");
        });

        modelBuilder.Entity<Usuariorol>(entity =>
        {
            entity.HasKey(e => new { e.Idusuario, e.Idrol }).HasName("pk_usuariorol");

            entity.ToTable("usuariorol");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Fechaasignacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaasignacion");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuariorol)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_usuarior_reference_roles");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Usuariorol)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_usuarior_reference_usuarios");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("pk_usuarios");

            entity.ToTable("usuarios");

            entity.Property(e => e.Idusuario)
                .ValueGeneratedNever()
                .HasColumnName("idusuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Bloqueadohasta)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("bloqueadohasta");
            entity.Property(e => e.Clavehash).HasColumnName("clavehash");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fechaactualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(30)
                .HasColumnName("identificacion");
            entity.Property(e => e.Intentosfallidos).HasColumnName("intentosfallidos");
            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(50)
                .HasColumnName("nombreusuario");
            entity.Property(e => e.Primerapellido)
                .HasMaxLength(50)
                .HasColumnName("primerapellido");
            entity.Property(e => e.Primernombre)
                .HasMaxLength(50)
                .HasColumnName("primernombre");
            entity.Property(e => e.Segundoapellido)
                .HasMaxLength(50)
                .HasColumnName("segundoapellido");
            entity.Property(e => e.Segundonombre)
                .HasMaxLength(50)
                .HasColumnName("segundonombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
