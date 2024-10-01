using Microsoft.AspNetCore.Mvc;

namespace Marfia_HairTonic.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
    }
}
