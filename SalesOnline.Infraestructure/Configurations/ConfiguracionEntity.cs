
using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Configuracion;

namespace SalesOnline.Infraestructure.Configurations
{
    public static class ConfiguracionEntity
    {
        public static void AddConfigurationConfiguracionEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Negocio>(entity =>
            {
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaElimino).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreLogo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeImpuesto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SimboloMoneda)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlLogo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NumeroCorrelativo>(entity =>
            {
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.Gestion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.Property(e => e.Propiedad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recurso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

        }
    }
}
