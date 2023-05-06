using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Almacen;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SalesContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Suplidores { get; set; }
        
    }
}
