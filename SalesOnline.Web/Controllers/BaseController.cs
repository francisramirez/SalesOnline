using Microsoft.AspNetCore.Mvc;

namespace SalesOnline.Web.Controllers
{
    public class BaseController : Controller
    {
        public string GetToken() => HttpContext.Session.GetString("myToken");
        public void SaveSessionToken(string token) => HttpContext.Session.SetString("myToken", token);
    }
}
