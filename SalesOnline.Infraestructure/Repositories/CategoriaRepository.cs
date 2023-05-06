using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SalesOnline.Domain.Entities.Almacen;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Interfaces;


namespace SalesOnline.Infraestructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria> ,ICategoriaRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<CategoriaRepository> logger;
        public CategoriaRepository(SalesContext context, 
                                   ILogger<CategoriaRepository> logger) :base(context)
        {
            this.context = context;
            this.logger = logger;
        }
      

    }
}
