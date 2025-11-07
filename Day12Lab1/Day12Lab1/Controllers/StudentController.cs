using Day12Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day12Lab1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>() {
                new Student()
                {
                    Id = 101,
                    Name = "Trần văn trình",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "tranvantrinh2k5@gmail.com"
                },
                new Student()
                {
                    Id = 102,
                    Name = "Lê thị hồng",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "B2-2019",
                    Email = " ",
                },
            };
        }
        [Route ("Admin/Student/List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [HttpGet]
        [Route ("Admin/Student/Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List< SelectListItem >()
            {
                new SelectListItem() { Text = "IT", Value = "1"},
                new SelectListItem() { Text = "BE", Value = "2"},
                new SelectListItem() { Text = "CE", Value = "3"},
                new SelectListItem() { Text = "EE", Value = "4"}
            };
            return View();
        }
        [HttpPost]
        [Route("Admin/Student/Add")]
        public IActionResult Create(Student student)
        {
            student.Id = listStudents.Last<Student>().Id+1;
            listStudents.Add(student);
            return View("Index",listStudents);
        }
    }
}
