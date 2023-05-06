using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesOnline.Infraestructure.Context;

namespace SalesOnline.IOC.Dependencies
{
    public static class ContextDependency
    {
        public static void AddContextDependency(this IServiceCollection services, string connString) 
        {
            services.AddDbContext<SalesContext>(options => options.UseSqlServer(connString));
        }
    }
}
