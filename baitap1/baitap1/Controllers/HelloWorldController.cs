using Microsoft.AspNetCore.Mvc;

namespace baitap1.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
