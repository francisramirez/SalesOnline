
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SalesOnline.Domain.Entities.Almacen;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Exceptions;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ProductoCategoriaModel> GetProductoCategoria(int productoId)
        {
            ProductoCategoriaModel productoCategoria = new ProductoCategoriaModel();

            try
            {
                var productCategories = context.Producto.Include(cd => cd.ProductoCategoria)
                                        .FirstOrDefault(cd => cd.Id == productoId);


                if (productCategories != null)
                {

                    // Detalle producto //
                    productoCategoria.ProductoModel.Descripcion = productCategories.Descripcion;
                    productoCategoria.ProductoModel.CodigoBarra = productCategories.CodigoBarra;
                    productoCategoria.ProductoModel.Marca = productCategories.Marca;
                    productoCategoria.ProductoModel.NombreImagen = productCategories.NombreImagen;
                    productoCategoria.ProductoModel.Precio = productCategories.Precio;
                    productoCategoria.ProductoModel.ProductoId = productCategories.Id;
                    productoCategoria.ProductoModel.Stock = productCategories.Stock;
                    productoCategoria.ProductoModel.UrlImagen = productCategories.UrlImagen;

                    productoCategoria.CategoriaModels = (from ca in this.context.Categoria.ToList()
                                                         join cal in productCategories.ProductoCategoria on ca.Id equals cal.CategoriaId
                                                         select new CategoriaModel()
                                                         {
                                                             CategoriaId = ca.Id,
                                                             Descripcion = ca.Descripcion
                                                         }).ToList();

                }

            }
            catch (Exception ex)
            {
                this.logger.LogError("error obteniendo los productos con sus categorias", ex.Message);
            }


            return productoCategoria;
        }

        public async override Task Save(Producto entity)
        {
            //if (!await this.context.Categoria.AnyAsync(cd => cd.Id == entity.IdCategoria))
            //{
            //    throw new ProductoException("La categoria no se encuentra registrada");
            //}


            await base.Save(entity);
            await base.SaveChanges();


        }
        public override async Task Update(Producto entity)
        {

            await base.Update(entity);
            await base.SaveChanges();
        }
    }
}
