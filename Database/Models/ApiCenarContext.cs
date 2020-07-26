using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Models
{
    public partial class ApiCenarContext : DbContext
    {
        public ApiCenarContext()
        {
        }

        public ApiCenarContext(DbContextOptions<ApiCenarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredientes> Ingredientes { get; set; }
        public virtual DbSet<IngredientesPlato> IngredientesPlato { get; set; }
        public virtual DbSet<Mesas> Mesas { get; set; }
        public virtual DbSet<OrdenPlatos> OrdenPlatos { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Platos> Platos { get; set; }
        public virtual DbSet<TiposEstados> TiposEstados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DJ6VOP6\\SQLEXPRESS; Database = ApiCenar; persist security info = True; Integrated Security = SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredientes>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<IngredientesPlato>(entity =>
            {
                entity.HasOne(d => d.IdIngredienteNavigation)
                    .WithMany(p => p.IngredientesPlato)
                    .HasForeignKey(d => d.IdIngrediente)
                    .HasConstraintName("FK_IngredientesPlato_Ingredientes");

                entity.HasOne(d => d.IdPlatoNavigation)
                    .WithMany(p => p.IngredientesPlato)
                    .HasForeignKey(d => d.IdPlato)
                    .HasConstraintName("FK_IngredientesPlato_Platos");
            });

            modelBuilder.Entity<Mesas>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Mesas)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__Mesas__Estado__37A5467C");
            });

            modelBuilder.Entity<OrdenPlatos>(entity =>
            {
                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.OrdenPlatos)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK_OrdenPlatos_Ordenes");

                entity.HasOne(d => d.IdPlatoNavigation)
                    .WithMany(p => p.OrdenPlatos)
                    .HasForeignKey(d => d.IdPlato)
                    .HasConstraintName("FK_OrdenPlatos_Platos");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.Property(e => e.Estado)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Subtotal).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.IdMesaNavigation)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdMesa)
                    .HasConstraintName("FK_Ordenes_Mesas");
            });

            modelBuilder.Entity<Platos>(entity =>
            {
                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Precio).HasColumnType("decimal(19, 2)");
            });

            modelBuilder.Entity<TiposEstados>(entity =>
            {
                entity.Property(e => e.EstadoDesc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
