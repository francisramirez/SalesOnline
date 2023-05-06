using Microsoft.EntityFrameworkCore;
using SalesOnline.Infraestructure.Dependencies;

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
            modelBuilder.AddDependencyAlmacenEntity();

            modelBuilder.AddDependencyVentaEntity();

            modelBuilder.AddDependencyConfiguracionEntity();

            modelBuilder.AddDependencySeguridadEntity();

            // base.OnModelCreating(modelBuilder);
        }

    }
}
