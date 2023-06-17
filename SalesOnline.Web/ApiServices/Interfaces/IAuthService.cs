using SalesOnline.Web.Models.Requests;
using SalesOnline.Web.Models.Responses;

namespace SalesOnline.Web.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest);
        Task<ObtenerTokenResponse> ObtenerTokenUsuario(ObtenerTokenRequest obtenerTokenRequest);
    }
}
