using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SalesOnline.Domain.Entities.Seguridad;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Models.Usuario;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace SalesOnline.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<UsuarioRepository> logger;

        public UsuarioRepository(SalesContext context, ILogger<UsuarioRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<UsuarioModel> GetUsuario(string correo, string clave)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            try
            {
                Usuario usuario = await this.context.Usuario.SingleOrDefaultAsync(us => us.Correo == correo
                                          && us.Clave == Encript.GetSHA256(clave));

                usuarioModel = new UsuarioModel()
                {
                    Correo = usuario.Correo,
                    Id = usuario.Id,
                    IdRol = usuario.IdRol,
                    Nombre = usuario.Nombre,
                    NombreFoto = usuario.NombreFoto,
                    Telefono = usuario.Telefono,
                    UrlFoto = usuario.UrlFoto
                };

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el usuario.", ex.Message);
            }

            return usuarioModel;
        }

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            var usuarios = (await FindAll(us => !us.Eliminado))
                           .Select(us => new UsuarioModel()
                           {
                               Correo = us.Correo,
                               Id = us.Id,
                               IdRol = us.IdRol,
                               Nombre = us.Nombre,
                               NombreFoto = us.NombreFoto,
                               Telefono = us.Telefono,
                               UrlFoto = us.UrlFoto

                           }).ToList();

            return usuarios;
        }

        public async override Task Save(Usuario entity)
        {
            await base.Save(entity);
            await base.SaveChanges();
        }


    }
}
