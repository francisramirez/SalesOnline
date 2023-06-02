using SalesOnline.Domain.Entities.Almacen;
using SalesOnline.Domain.Repository;
using SalesOnline.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesOnline.Infraestructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        Task<List<Producto>> GetProductByCategory(int categoryId);
        Task<ProductoCategoriaModel> GetProductoCategoria(int productoId);
    }
}
