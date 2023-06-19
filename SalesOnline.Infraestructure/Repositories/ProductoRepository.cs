
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
        public async Task<List<ProductoModel>> GetProductsByCategory(int categoryId)
        {
            List<ProductoModel> productos = new List<ProductoModel>();

            try
            {
                productos = (from pro in (await base.GetAll()).ToList()
                             join proca in context.ProductoCategoria.ToList() on pro.Id equals proca.ProductoId
                             join ca in context.Categoria.ToList() on proca.CategoriaId equals ca.Id
                             where proca.CategoriaId == categoryId
                             select new ProductoModel()
                             {
                                 CodigoBarra = pro.CodigoBarra,
                                 Descripcion = pro.Descripcion,
                                 IdCategoria = proca.CategoriaId,
                                 Marca = pro.Marca,
                                 NombreImagen = pro.NombreImagen,
                                 Precio = pro.Precio,
                                 ProductoId = pro.Id,
                                 Stock = pro.Stock,
                                 UrlImagen = pro.UrlImagen,
                                 Categoria = ca.Descripcion
                             }).ToList();

            }
            catch (Exception ex)
            {
                this.logger.LogError("error obteniendo los productos con sus categorias", ex.Message);

            }

            return productos;
        }

        public async Task<ProductoCategoriaModel> GetProductoCategoria(int productoId)
        {
            ProductoCategoriaModel productoCategoria = new ProductoCategoriaModel();

            try
            {
                var productCategories =  await context.Producto.Include(cd => cd.ProductoCategoria)
                                                              .FirstOrDefaultAsync(cd => cd.Id == productoId);


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
          
            await Task.WhenAll(
                   base.Save(entity),
                   base.SaveChanges()
                );


        }
        public override async Task Update(Producto entity)
        {

            await Task.WhenAll(
                    base.Update(entity),
                    base.SaveChanges()

                );
            ;

        }
    }
}
