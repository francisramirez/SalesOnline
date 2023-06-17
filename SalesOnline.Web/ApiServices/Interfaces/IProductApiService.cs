using SalesOnline.Web.Models.Requests;
using SalesOnline.Web.Models.Responses;

namespace SalesOnline.Web.ApiServices.Interfaces
{
    public interface IProductApiService : IBaseApiService
    {
        Task<ProductoListResponse> GetProductos();
        Task<ProductoGetResponse> GetProducto(int Id);
        Task<ProductAddReponse> SaveProducto(ProductSaveRequest productRequest);
        Task<ResponseBase> UpdateProducto(ProductSaveRequest productRequest);
    }
}
