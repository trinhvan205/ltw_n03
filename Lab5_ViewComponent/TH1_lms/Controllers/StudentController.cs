using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TH1_lms.Models;

namespace TH1_lms.Controllers
{
    public class StudentController : Controller
    {
        //private List<Student> listStudents;
        //public StudentController()
        //{
        //    listStudents = new List<Student>()
        //    {
        //        new Student() 
        //        { 
        //            Id = 101,
        //            Name = "Hải Nam",
        //            Branch = Branch.IT,
        //            Gender = Gender.Male,
        //            IsRegular=true,
        //            Address = "A1-2018",
        //            Email = "nam@g.com" 
        //        },

        //        new Student() 
        //        { 
        //            Id = 102,
        //            Name = "Minh Tú",
        //            Branch = Branch.BE,
        //            Gender = Gender.Female,
        //            IsRegular=true,
        //            Address = "A1-2019",
        //            Email = "tu@g.com"
        //        },

        //        new Student() 
        //        { 
        //            Id = 103,
        //            Name = "Hoàng Phong",
        //            Branch = Branch.CE,
        //            Gender = Gender.Male,
        //            IsRegular=false,
        //            Address = "A1-2020",
        //            Email = "phong@g.com" 
        //        },
        //        new Student() 
        //        { 
        //            Id = 104,
        //            Name = "Xuân Mai",
        //            Branch= Branch.EE,
        //            Gender = Gender.Female,
        //            IsRegular = false,
        //            Address = "A1-2021",
        //            Email = "mai@g.com" 
        //        }

        //    };

        //}

        //sử dụng cái này vì mỗi lần Controller được tạo thì ds sẽ ko bị reset lại và dữ liệu k bị mất
        private static List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            //tạo danh sách sinh viên vs 4 dữ liệu mẫu 
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Việt Anh", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true, Address = "A1-2018", Email = "vieanh.nguyen190105@gmail.com" },
                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.Female, IsRegular=true, Address = "A1-2019", Email = "tu@g.com" },
                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male, IsRegular=false, Address = "A1-2020", Email = "phong@g.com" },
                new Student() { Id = 104, Name = "Xuân Mai", Branch= Branch.EE, Gender = Gender.Female, IsRegular = false, Address = "A1-2021", Email = "mai@g.com" }
            };
        }

        [Route("Admin/Student/List")] //cấu hình route cho Student/Index -> Admin/Student/List
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        [Route("Admin/Student/Add")] //cấu hình route cho Student/Create -> Admin/Student/Add
        public IActionResult Create()
        {
            //lấy ds các gtri Gender để hiện thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            //lấy ds các Branch để hiện thị select-option
            //để hiện thị select-op cần dùng List<SelectListItem>
            ViewBag.AllBranchs = new List<SelectListItem>()
            {
                new SelectListItem {Text = "IT", Value = "1"},
                new SelectListItem {Text = "BE", Value = "2"},
                new SelectListItem {Text = "CE", Value = "3"},
                new SelectListItem {Text = "EE", Value = "4"},
            };
            
            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add")] //cấu hình route cho Student/Create -> Admin/Student/Add
        public IActionResult Create(Student s)
        {
            if(ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
            //Nếu không đúng thì làm lại như [HttpGet]
            ViewBag.AllGenders = Enum.GetValues(typeof (Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranchs = new List<SelectListItem>()
            {
                new SelectListItem {Text = "IT", Value = "1"},
                new SelectListItem {Text = "BE", Value = "2"},
                new SelectListItem {Text = "CE", Value = "3"},
                new SelectListItem {Text = "EE", Value = "4"},

            };
            return View();
        }
    }
}
