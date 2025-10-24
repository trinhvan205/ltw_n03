using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tvt_231230930_de01.Models;

namespace Tvt_231230930_de01.Controllers
{
    public class TvtHomeController : Controller
    {
        private readonly ILogger<TvtHomeController> _logger;

        public TvtHomeController(ILogger<TvtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TvtIndex()
        {
            return View();
        }

        public IActionResult TvtPrivacy()
        {
            return View();
        }
        public IActionResult TvtContact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
