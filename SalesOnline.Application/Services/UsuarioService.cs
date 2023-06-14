using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Usuario;
using SalesOnline.Domain.Entities.Seguridad;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Interfaces;


namespace SalesOnline.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        public async Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await this.usuarioRepository
                                        .GetUsuario(getUsuarioInfoDto.Correo, 
                                                    getUsuarioInfoDto.Clave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la información del usuario.";
                this.logger.LogError($"{ result.Message }  { ex.Message}", ex.ToString());
            }


            return result;
        }

        public async Task<ServiceResult> SaveUsuario(UsaurioAddDto productAddDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Usuario usuario = new Usuario()
                {
                    Correo = productAddDto.Correo,
                    Nombre = productAddDto.Nombre,
                    Clave = Encript.GetSHA256(productAddDto.Clave),
                    IdRol = productAddDto.IdRol,
                    NombreFoto = productAddDto.NombreFoto,
                    IdUsuarioCreacion = productAddDto.IdUsuario,
                    Telefono = productAddDto.Telefono,
                    UrlFoto = productAddDto.UrlFoto
                };

                await this.usuarioRepository.Save(usuario);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el usuario: ";
                this.logger.LogError($"{result.Message} {ex.Message}", ex.ToString());

            }

            return result;
        }
       
    }
}
