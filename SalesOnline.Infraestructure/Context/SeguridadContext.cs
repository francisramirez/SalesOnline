
using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities.Seguridad;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SalesContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
