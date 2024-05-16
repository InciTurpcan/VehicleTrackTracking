using Microsoft.AspNetCore.Mvc;

namespace Vehcile_Track_WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
