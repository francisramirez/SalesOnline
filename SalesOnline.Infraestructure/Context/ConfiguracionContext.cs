
using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Configuracion;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SalesContext
    {
        public DbSet<NumeroCorrelativo> NumeroCorrelativo { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Negocio>  Negocio { get; set; }
    }
}
