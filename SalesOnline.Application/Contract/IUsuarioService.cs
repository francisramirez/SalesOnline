using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Producto;
using SalesOnline.Application.Dtos.Usuario;
using SalesOnline.Application.Responses;
using System.Threading.Tasks;

namespace SalesOnline.Application.Contract
{
    public interface IUsuarioService
    {
        Task<ServiceResult> SaveUsuario(UsaurioAddDto productAddDto);

        Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto); 
         

    }
}
