using Microsoft.EntityFrameworkCore;
using SalesOnline.Infraestructure.Configurations;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SalesContext : DbContext
    {
        public SalesContext()
        {

        }
        public SalesContext(DbContextOptions<SalesContext> options)
               : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfigurationAlmacenEntity();

            modelBuilder.AddConfigurationConfiguracionEntity();

            modelBuilder.AddConfigurationVentaEntity();

            modelBuilder.AddConfigurationSeguridadEntity();

            base.OnModelCreating(modelBuilder);
        }
      
    }
}
