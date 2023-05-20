using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Producto;
using SalesOnline.Application.Responses;
using System.Threading.Tasks;

namespace SalesOnline.Application.Contract
{
    public interface IProductoService
    {
       Task<ServiceResult> Get();
       Task<ServiceResult> GetById(int Id);
       Task<ProductAddResponse> SaveProduct(ProductAddDto productAddDto);
       Task<ServiceResult> ModifyProduct(ProductUpdateDto productUpdateDto);

    }
}
