using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Almacen;

namespace SalesOnline.Infraestructure.Configurations
{
    public static class AlmacenConfigurationEntity
    {
        public static void AddConfigurationAlmacenEntity(this ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Categoria>(entity =>
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

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.CodigoBarra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaElimino).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductoCategoria>(entity =>
            {
                entity.HasKey(e => new { e.ProductoId, e.CategoriaId });

                entity.Property(e => e.ProductoId).HasColumnName("Producto_Id");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_Id");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.ProductoCategoria)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoCategoria_Categoria_Id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoCategoria)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoCategoria_Producto_Id");
            });

        }
    }
}
