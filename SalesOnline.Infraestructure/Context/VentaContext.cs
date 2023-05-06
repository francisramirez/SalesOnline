using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Ventas;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SalesContext
    {
        public  DbSet<DetalleVenta> DetalleVenta { get; set; }
        public  DbSet<Venta> Venta { get; set; }
        public DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set; }

    }
}
