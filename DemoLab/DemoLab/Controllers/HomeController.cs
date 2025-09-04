using Microsoft.AspNetCore.Mvc;
using DemoLab.Models;

namespace DemoLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Giả lập danh sách sản phẩm mới nhất
            var products = new List<Product>
            {
                new Product{ Id=1, Name="Nồi cơm điện cao tần Nagakawa NAG0102", Image="noicom.jpg"},
                new Product{ Id=2, Name="Nồi cơm điện cao tần Nagakawa NAG0102", Image="noicom.jpg"},
                new Product{ Id=3, Name="Nồi cơm điện cao tần Nagakawa NAG0102", Image="noicom.jpg"},
            };
            return View(products);
        }
    }
}
