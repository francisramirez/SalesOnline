
using Microsoft.Extensions.DependencyInjection;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Services;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Repositories;

namespace SalesOnline.IOC.Dependencies
{
    public static class AlmancenDependency
    {
        public static void AddAlmacenDependency(this IServiceCollection services) 
        {

            #region "Repositories"
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            #endregion

            #region "Services"
            services.AddTransient<IProductoService, ProductoService>();
            #endregion

        }
    }
}
