
using Microsoft.Extensions.DependencyInjection;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Services;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Repositories;

namespace SalesOnline.IOC.Dependencies
{
    public static class SeguridadDependency
    {
        public static void AddSecurityDependency(this IServiceCollection services)
        {

            #region "Repositories"
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region "Services"
            services.AddTransient<IUsuarioService, UsuarioService>();
            #endregion

        }
    }
}
