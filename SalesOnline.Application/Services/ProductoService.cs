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
                var query = (from prod in (await this.productoRepository.GetAll())
                             join cate in (await this.categoriaRepository.GetAll()) on prod.IdCategoria equals cate.Id
                             select new Models.ProductGetModel()
                             {
                                 Categoria = cate.Descripcion,
                                 Descripcion = prod.Descripcion,
                                 Marca = prod.Marca,
                                 Precio = prod.Precio,
                                 ProductoId = prod.Id,
                                 Stock = prod.Stock
                             }).ToList();

                result.Data = query;

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
                var prodModel = (from prod in (await this.productoRepository.GetAll())
                                 join cate in (await this.categoriaRepository.GetAll()) on prod.IdCategoria equals cate.Id
                                 where prod.Id == Id
                                 select new Models.ProductGetModel()
                                 {
                                     Categoria = cate.Descripcion,
                                     Descripcion = prod.Descripcion,
                                     Marca = prod.Marca,
                                     Precio = prod.Precio,
                                     ProductoId = prod.Id,
                                     Stock = prod.Stock
                                 }).FirstOrDefault();


                result.Data = prodModel;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }
        public Task<ProductAddResponse> ModifyProduct(ProductUpdateDto productUpdateDto)
        {
            throw new System.NotImplementedException();
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

                Producto producto = new Producto()
                {
                    CodigoBarra = productAddDto.CodigoBarra,
                    Descripcion = productAddDto.Descripcion,
                    Eliminado = false,
                    EsActivo = true,
                    IdCategoria = productAddDto.IdCategoria,
                    IdUsuarioCreacion = productAddDto.IdUsuario,
                    Marca = productAddDto.Marca,
                    Precio = productAddDto.Precio,
                    NombreImagen = productAddDto.NombreImagen,
                    Stock = productAddDto.Stock,
                    UrlImagen = productAddDto.UrlImagen,
                    FechaRegistro = DateTime.Now
                };

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
    }
}
