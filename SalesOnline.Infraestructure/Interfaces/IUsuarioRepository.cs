using SalesOnline.Domain.Entities.Seguridad;
using SalesOnline.Domain.Repository;
using SalesOnline.Infraestructure.Models.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesOnline.Infraestructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuario(string correo, string pwd);
    }
}
