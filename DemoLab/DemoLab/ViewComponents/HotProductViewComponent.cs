using Microsoft.AspNetCore.Mvc;
using DemoLab.Models;

namespace DemoLab.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Giả lập danh sách sản phẩm hot
            var hotProducts = new List<Product>
            {
                new Product{ Id=4, Name="Nồi cơm điện cao tần Nagakawa NAG0102", Image="noicom.jpg"},
                new Product{ Id=5, Name="Nồi cơm điện cao tần Nagakawa NAG0102", Image="noicom.jpg"},
                new Product{ Id=6, Name="Nồi cơm điện cao tần Nagakawa NAG0102", Image="noicom.jpg"},
            };
            return View(hotProducts);
        }
    }
}
