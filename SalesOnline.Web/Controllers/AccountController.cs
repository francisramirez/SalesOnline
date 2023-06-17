using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.Models.Requests;

namespace SalesOnline.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ObtenerTokenRequest request) 
        {

            var result = await this.authService.ObtenerTokenUsuario(request);

            if (!result.success)
                ViewBag.Message = result.message;

            // guardar la informacion del token //
            base.SaveSessionToken(result.data.token);

            return RedirectToAction("Index","Producto");
        }
    }
}
