using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Producto;
using SalesOnline.Application.Responses;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Domain.Entities.Almacen;
using SalesOnline.Application.Extentions;
using System.Collections.Generic;

namespace SalesOnline.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;
        private readonly ICategoriaRepository categoriaRepository;
        private readonly ILogger<ProductoService> logger;

        public ProductoService(IProductoRepository productoRepository,
                               ICategoriaRepository categoriaRepository,
                               ILogger<ProductoService> logger)
        {
            this.productoRepository = productoRepository;
            this.categoriaRepository = categoriaRepository;
            this.logger = logger;
        }
        public async Task<ServiceResult> Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await getProductos();

            }
            catch (Exception ex)
            {
                // enviar notificacion //
                result.Success = false;
                result.Message = "Error obteniendo los productos";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }
        public async Task<ServiceResult> GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (await this.getProductos(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }
        public async Task<ServiceResult> ModifyProduct(ProductUpdateDto productUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (string.IsNullOrEmpty(productUpdateDto.CodigoBarra))
                {
                    result.Message = "Código de barra es requerido";
                    result.Success = false;
                    return result;
                }

                if (productUpdateDto.CodigoBarra.Length > 50)
                {
                    result.Message = "Logitud inválidad";
                    result.Success = false;
                    return result;
                }


                Producto producto = await this.productoRepository.GetEntityById(productUpdateDto.ProductoId);

                producto.CodigoBarra = productUpdateDto.CodigoBarra;
                producto.Marca = productUpdateDto.Marca;
                producto.Precio = productUpdateDto.Precio;
                producto.Stock = productUpdateDto.Stock;
                producto.UrlImagen = productUpdateDto.UrlImagen;
                producto.NombreImagen = productUpdateDto.NombreImagen;
                producto.IdCategoria = productUpdateDto.IdCategoria;
                producto.Descripcion = productUpdateDto.Descripcion;
                producto.FechaMod = DateTime.Now;
                producto.IdUsuarioMod = productUpdateDto.IdUsuario;

                await this.productoRepository.Update(producto);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando el producto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }
        public async Task<ProductAddResponse> SaveProduct(ProductAddDto productAddDto)
        {
            ProductAddResponse productAddResponse = new ProductAddResponse();

            try
            {
                if (string.IsNullOrEmpty(productAddDto.CodigoBarra))
                {
                    productAddResponse.Message = "Código de barra es requerido";
                    productAddResponse.Success = false;
                    return productAddResponse;
                }

                if (productAddDto.CodigoBarra.Length > 50)
                {
                    productAddResponse.Message = "Logitud inválidad";
                    productAddResponse.Success = false;
                    return productAddResponse;
                }

                Producto producto = productAddDto.ConvertDtoAddProductToProduct();

                await this.productoRepository.Save(producto);

                productAddResponse.ProductId = producto.Id;


            }
            catch (Exception ex)
            {
                productAddResponse.Success = false;
                productAddResponse.Message = "Error agregando el producto";
                this.logger.Log(LogLevel.Error, $" {productAddResponse.Message}", ex.ToString());
            }

            return productAddResponse;
        }
        private async Task<List<Models.ProductGetModel>> getProductos(int? Id = null)
        {
            List<Models.ProductGetModel> products = new List<Models.ProductGetModel>();

            try
            {

                //if (Id.HasValue)
                //{

                //}

                //products = (from prod in (await this.productoRepository.GetAll())
                //            join cate in (await this.categoriaRepository.GetAll()) on prod.IdCategoria equals cate.Id
                //            where prod.Id == ( Id.HasValue ? Id : prod.Id)
                //            select new Models.ProductGetModel()
                //            {
                //                Categoria = cate.Descripcion,
                //                Descripcion = prod.Descripcion,
                //                Marca = prod.Marca,
                //                Precio = prod.Precio,
                //                ProductoId = prod.Id,
                //                Stock = prod.Stock
                //            }).ToList();


                products = (from prod in (await this.productoRepository.GetAll())
                            join cate in (await this.categoriaRepository.GetAll()) on prod.IdCategoria equals cate.Id
                            where prod.Id == Id || !Id.HasValue
                            select new Models.ProductGetModel()
                            {
                                Categoria = cate.Descripcion,
                                Descripcion = prod.Descripcion,
                                Marca = prod.Marca,
                                Precio = prod.Precio,
                                ProductoId = prod.Id,
                                Stock = prod.Stock,
                                CodigoBarra = prod.CodigoBarra, 
                                IdCategoria= prod.IdCategoria, 
                                NombreImagen = prod.NombreImagen, 
                                UrlImagen = prod.UrlImagen
                            }).ToList();
            }
            catch (Exception ex)
            {
                products = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los productos", ex.ToString());
            }

            return products;
        }
    }
}
