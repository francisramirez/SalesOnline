using Microsoft.AspNetCore.Mvc;
using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.Models.Requests;

namespace SalesOnline.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> Index() 
        {
            return View();
        }
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserRequest createUserRequest) 
        {

            createUserRequest.idUsuario = 1;
            createUserRequest.fecha = DateTime.Now;


            var result = await this.authService.CreateUser(createUserRequest);

            if (!result.success)
            {
                ViewBag.Message = result.message;
               
                return View();
            }

            return RedirectToAction(nameof(Index));


        }



    }
}
