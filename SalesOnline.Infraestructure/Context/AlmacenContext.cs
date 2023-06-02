using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Almacen;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SalesContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoCategoria> ProductoCategoria { get; set; }

    }
}
