using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Facturacion.Modal {
    public partial class facturacionContext : DbContext {
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Asientocontable> Asientocontable { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Condicionpago> Condicionpago { get; set; }
        public virtual DbSet<Detallesfactura> Detallesfactura { get; set; }
        public virtual DbSet<Facturacion> Facturacion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }

        public facturacionContext (DbContextOptions<facturacionContext> options) : base (options) { }
        //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //         {
        //             if (!optionsBuilder.IsConfigured)
        //             {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                 optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Sebastian.1205;database=facturacion");
        //             }
        //         }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Articulos> (entity => {
                entity.HasKey (e => e.ArticuloId);

                entity.ToTable ("articulos");

                entity.Property (e => e.ArticuloId)
                    .HasColumnName ("ArticuloID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Descripcion)
                    .IsRequired ()
                    .HasMaxLength (50);

                entity.Property (e => e.Estado).HasColumnType ("bit(1)");
            });

            modelBuilder.Entity<Asientocontable> (entity => {
                entity.HasKey (e => e.AsientoId);

                entity.ToTable ("asientocontable");

                entity.HasIndex (e => e.ClienteId)
                    .HasName ("ClienteID");

                entity.Property (e => e.AsientoId)
                    .HasColumnName ("AsientoID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.ClienteId)
                    .HasColumnName ("ClienteID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Cuenta)
                    .IsRequired ()
                    .HasColumnType ("char(15)");

                entity.Property (e => e.Descripcion)
                    .IsRequired ()
                    .HasMaxLength (120);

                entity.Property (e => e.Estado).HasColumnType ("bit(1)");

                entity.Property (e => e.FechaAsiento).HasColumnType ("datetime");

                entity.Property (e => e.TipoMovimiento).HasColumnType ("bit(1)");

                entity.HasOne (d => d.Cliente)
                    .WithMany (p => p.Asientocontable)
                    .HasForeignKey (d => d.ClienteId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("asientocontable_ibfk_1");
            });

            modelBuilder.Entity<Clientes> (entity => {
                entity.HasKey (e => e.ClienteId);

                entity.ToTable ("clientes");

                entity.HasIndex (e => e.Cedula)
                    .HasName ("Cedula")
                    .IsUnique ();

                entity.HasIndex (e => e.CuentaContable)
                    .HasName ("CuentaContable")
                    .IsUnique ();

                entity.Property (e => e.ClienteId)
                    .HasColumnName ("ClienteID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Cedula)
                    .IsRequired ()
                    .HasColumnType ("char(11)");

                entity.Property (e => e.CuentaContable)
                    .IsRequired ()
                    .HasColumnType ("char(15)");

                entity.Property (e => e.Estado).HasColumnType ("bit(1)");

                entity.Property (e => e.Nombre)
                    .IsRequired ()
                    .HasMaxLength (30);
            });

            modelBuilder.Entity<Condicionpago> (entity => {
                entity.HasKey (e => e.PagoId);

                entity.ToTable ("condicionpago");

                entity.Property (e => e.PagoId)
                    .HasColumnName ("PagoID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Descripcion)
                    .IsRequired ()
                    .HasMaxLength (50);

                entity.Property (e => e.Dias).HasColumnType ("int(11)");

                entity.Property (e => e.Estado).HasColumnType ("bit(1)");
            });

            modelBuilder.Entity<Detallesfactura> (entity => {
                entity.HasKey (e => e.DetalleId);

                entity.ToTable ("detallesfactura");

                entity.HasIndex (e => e.ArticuloId)
                    .HasName ("ArticuloID");

                entity.HasIndex (e => e.FacturaId)
                    .HasName ("FacturaID");

                entity.Property (e => e.DetalleId)
                    .HasColumnName ("DetalleID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.ArticuloId)
                    .HasColumnName ("ArticuloID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.FacturaId)
                    .HasColumnName ("FacturaID")
                    .HasColumnType ("int(11)");

                entity.HasOne (d => d.Articulo)
                    .WithMany (p => p.Detallesfactura)
                    .HasForeignKey (d => d.ArticuloId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("detallesfactura_ibfk_1");

                entity.HasOne (d => d.Factura)
                    .WithMany (p => p.Detallesfactura)
                    .HasForeignKey (d => d.FacturaId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("detallesfactura_ibfk_2");
            });

            modelBuilder.Entity<Facturacion> (entity => {
                entity.HasKey (e => e.FacturaId);

                entity.ToTable ("facturacion");

                entity.HasIndex (e => e.ClienteId)
                    .HasName ("ClienteID");

                entity.HasIndex (e => e.VendedorId)
                    .HasName ("VendedorID");

                entity.Property (e => e.FacturaId)
                    .HasColumnName ("FacturaID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Cantidad).HasColumnType ("int(11)");

                entity.Property (e => e.ClienteId)
                    .HasColumnName ("ClienteID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Comentario)
                    .IsRequired ()
                    .HasMaxLength (50);

                entity.Property (e => e.Fecha).HasColumnType ("datetime");

                entity.Property (e => e.TipoPago)
                    .IsRequired ()
                    .HasMaxLength (50);

                entity.Property (e => e.VendedorId)
                    .HasColumnName ("VendedorID")
                    .HasColumnType ("int(11)");

                entity.HasOne (d => d.Cliente)
                    .WithMany (p => p.Facturacion)
                    .HasForeignKey (d => d.ClienteId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("facturacion_ibfk_2");

                entity.HasOne (d => d.Vendedor)
                    .WithMany (p => p.Facturacion)
                    .HasForeignKey (d => d.VendedorId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("facturacion_ibfk_1");
            });

            modelBuilder.Entity<Usuarios> (entity => {
                entity.HasKey (e => e.UsuarioId);

                entity.ToTable ("usuarios");

                entity.HasIndex (e => e.VendedorId)
                    .HasName ("VendedorID");

                entity.Property (e => e.UsuarioId)
                    .HasColumnName ("UsuarioID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Clave)
                    .IsRequired ()
                    .HasColumnType ("char(12)");

                entity.Property (e => e.VendedorId)
                    .HasColumnName ("VendedorID")
                    .HasColumnType ("int(11)");

                entity.HasOne (d => d.Vendedor)
                    .WithMany (p => p.Usuarios)
                    .HasForeignKey (d => d.VendedorId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("usuarios_ibfk_1");
            });

            modelBuilder.Entity<Vendedores> (entity => {
                entity.HasKey (e => e.VendedorId);

                entity.ToTable ("vendedores");

                entity.Property (e => e.VendedorId)
                    .HasColumnName ("VendedorID")
                    .HasColumnType ("int(11)");

                entity.Property (e => e.Estado).HasColumnType ("bit(1)");

                entity.Property (e => e.Nombre)
                    .IsRequired ()
                    .HasMaxLength (50);
            });
        }
    }
}