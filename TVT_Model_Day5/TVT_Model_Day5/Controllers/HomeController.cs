using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TVT_Model_Day5.Models;

namespace TVT_Model_Day5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var employees = new List<Employee>();
            var employee1 = new Employee();
            employee1.id = 1;
            employee1.fullName = "Nguyễn Văn An";
            employee1.gender = "Nam";
            employee1.phone = "0905123456";
            employee1.email = "an.nguyen@example.com";
            employee1.salary = 12000000;
            employee1.status = "Đang làm việc";
            var employee2 = new Employee();
            employee2.id = 2;
            employee2.fullName = "Trần Thị Bình";
            employee2.gender = "Nữ";
            employee2.phone = "0912345678";
            employee2.email = "binh.tran@example.com";
            employee2.salary = 10000000;
            employee2.status = "Đang làm việc";
            var employee3 = new Employee();
            employee3.id = 3;
            employee3.fullName = "Lê Hoàng Nam";
            employee3.gender = "Nam";
            employee3.phone = "0923456789";
            employee3.email = "nam.le@example.com";
            employee3.salary = 15000000;
            employee3.status = "Nghỉ phép";
            var employee4 = new Employee();
            employee4.id = 4;
            employee4.fullName = "Phạm Thúy Lan";
            employee4.gender = "Nữ";
            employee4.phone = "0934567890";
            employee4.email = "lan.pham@example.com";
            employee4.salary = 13000000;
            employee4.status = "Đang làm việc";
            var employee5 = new Employee();
            employee5.id = 5;
            employee5.fullName = "Hoàng Minh Tuấn";
            employee5.gender = "Nam";
            employee5.phone = "0945678901";
            employee5.email = "tuan.hoang@example.com";
            employee5.salary = 11000000;
            employee5.status = "Đang làm việc";
            var employee6 = new Employee();
            employee6.id = 6;
            employee6.fullName = "Đỗ Thị Hương";
            employee6.gender = "Nữ";
            employee6.phone = "0956789012";
            employee6.email = "huong.do@example.com";
            employee6.salary = 12500000;
            employee6.status = "Nghỉ việc";
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);
            employees.Add(employee4);
            employees.Add(employee5);
            employees.Add(employee6);
            ViewBag.Employees = employees;
            return View();
        }   

        public IActionResult Privacy()
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
