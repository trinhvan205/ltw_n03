using Microsoft.AspNetCore.Mvc;

namespace btvn22_8.Controllers
{
    public class HiWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
