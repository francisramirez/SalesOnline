using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.ApiServices.Services;

namespace SalesOnline.Web.Dependencies
{
    public static class AuthDependencyApi
    {
        public static void AddAuthDependencyApi(this IServiceCollection services) 
        {
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
