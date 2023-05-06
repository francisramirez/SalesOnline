
using Microsoft.Extensions.DependencyInjection;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Repositories;

namespace SalesOnline.IOC.Dependencies
{
    public static class AlmancenDependency
    {
        public static void AddAlmacenDependency(this IServiceCollection services) 
        {
            //Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            
        }
    }
}
