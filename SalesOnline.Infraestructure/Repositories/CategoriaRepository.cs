using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async override Task<IEnumerable<Categoria>> GetAll()
        {
            List<Categoria> categorias = new List<Categoria>();
          
            try
            {
              
                categorias =  await  this.context.Categoria.Where(cd => !cd.Eliminado).ToListAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo las categorias", ex.ToString());
            }

            return categorias;
        }



    }
}
