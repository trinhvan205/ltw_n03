using Microsoft.AspNetCore.Mvc;
using Annotation_Test_TrenLop.Models;

namespace Annotation_Test_TrenLop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserManualValid()
        {

            return View();
        }

        [HttpPost]
        public IActionResult UserManualValid(User u)
        {
            string pass = u.Password;
            if(pass.Length < 7)
            {
                ViewBag.Pass = "Mật khẩu phải có ít nhất 7 kí tự";
                return View();
            }
            return Content("bạn đã nhập đúng");
        }

        [HttpGet]
        public IActionResult UserManualValid1()
        {

            return View();
        }

        public IActionResult UserAnnotation()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UserAnnotation(User u)
        {
            if(ModelState.IsValid)
            {
                return Content("haha thoát rồi");
            }
            return View();
        }
    }
}
