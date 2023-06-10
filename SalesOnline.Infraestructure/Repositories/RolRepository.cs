

using SalesOnline.Domain.Entities.Seguridad;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Interfaces;

namespace SalesOnline.Infraestructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(SalesContext context) : base(context)
        {
             
        }
        
    }
}
