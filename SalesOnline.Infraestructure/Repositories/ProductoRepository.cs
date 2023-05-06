
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SalesOnline.Domain.Entities.Almacen;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Exceptions;
using SalesOnline.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesOnline.Infraestructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<ProductoRepository> logger;

        public ProductoRepository(SalesContext context,
                                   ILogger<ProductoRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<List<Producto>> GetProductByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }
        public async override Task Save(Producto entity)
        {
            if (!await this.context.Categoria.AnyAsync(cd => cd.Id == entity.IdCategoria))
            {
                throw new ProductoException("La categoria no se encuentra registrada");
            }


            await base.Save(entity);
            await base.SaveChanges();


        }
    }
}
