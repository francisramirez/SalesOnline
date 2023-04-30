using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SaleContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Suplidor> Suplidores { get; set; }
        
    }
}
