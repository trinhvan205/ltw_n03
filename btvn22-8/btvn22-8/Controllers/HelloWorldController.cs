using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace btvn22_8.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
