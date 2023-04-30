using Microsoft.Extensions.Logging;
using SalesOnline.Domain.Entities;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace SalesOnline.Infraestructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria> ,ICategoriaRepository
    {
        private readonly SaleContext context;
        private readonly ILogger<CategoriaRepository> logger;
        public CategoriaRepository(SaleContext context, 
                                   ILogger<CategoriaRepository> logger) :base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public async override Task Save(Categoria entity)
        {
            try
            {
                await base.Save(entity);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error guardando la categoria", ex.ToString());
            }
        }

    }
}
