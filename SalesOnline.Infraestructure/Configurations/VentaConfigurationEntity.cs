using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Ventas;

namespace SalesOnline.Infraestructure.Configurations
{
    public static class VentaConfigurationEntity
    {
        public static void AddConfigurationVentaEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("Cantidad");

                entity.Property(e => e.CategoriaProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CategoriaProducto");

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DescripcionProducto");

                entity.Property(e => e.IdProducto).HasColumnName("IdProducto");

                entity.Property(e => e.IdVenta).HasColumnName("IdVenta");

                entity.Property(e => e.MarcaProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MarcaProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Precio");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Total");
              
            });

            modelBuilder.Entity<TipoDocumentoVenta>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaElimino).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.CocumentoCliente)
                    .HasMaxLength(10)
                    .IsUnicode(false);
               
                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImpuestoTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroVenta)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
               
            });
        }
    }
    
}
