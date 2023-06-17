using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.ApiServices.Services;

namespace SalesOnline.Web.Dependencies
{
    public static class ApiAlmancenDependency
    {
        public static void AddApiAlmancenDependency(this IServiceCollection services) 
        {
            services.AddTransient<IProductApiService, ProductApiService>();
        }
    }
}
