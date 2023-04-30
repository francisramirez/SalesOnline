using Microsoft.AspNetCore.Mvc;

namespace SalesOnline.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() 
        {
            return View();
        }
    }
}
