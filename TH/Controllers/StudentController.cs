using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bài_TH_01.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Bài_TH_01.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<StudentController> _logger;
        private static List<Student> ListStudents = new List<Student>();

        public StudentController(IWebHostEnvironment env, ILogger<StudentController> logger)
        {
            _env = env;
            _logger = logger;

            // initialize once (don't overwrite the static list every time)
            if (!ListStudents.Any())
            {
                ListStudents = new List<Student>()
                {
                    new Student() { Id = 1, Name = "Nguyen Van An", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "b099-8ih", Email = "an123@g.com" },
                    new Student() { Id = 2, Name = "Tran Thi Be", Branch = Branch.BE, Gender = Gender.Female, IsRegular = true, Address = "b099-9ih", Email = "be@g.com" },
                    new Student() { Id = 3, Name = "Le Van Cuong", Branch = Branch.CE, Gender = Gender.Male, IsRegular = false, Address = "b099-5ah", Email = "Cuong@g.com" },
                    new Student() { Id = 4, Name = "Pham Thi Dinh", Branch = Branch.EE, Gender = Gender.Female, IsRegular = false, Address = "b099-1kh", Email = "Dinh@g.com" }
                };
            }
        }

        [Route("List", Name = "StudentList")]
        public IActionResult Index()
        {
            return View(ListStudents);
        }

        [HttpGet("Add", Name = "CreateStudentForm")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };
            return View();
        }

        [HttpPost("Add", Name = "CreateStudentPost")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student s, IFormFile? photo)
        {
            // Save uploaded photo (optional) so photo validation does not block model state
            if (photo != null && photo.Length > 0)
            {
                var uploadsDir = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                var ext = Path.GetExtension(photo.FileName);
                var fileName = $"{Guid.NewGuid():N}{ext}";
                var filePath = Path.Combine(uploadsDir, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(stream);

                s.PhotoPath = $"/uploads/{fileName}";
            }

            // remove validation error that was created during model binding
            ModelState.Remove(nameof(Bài_TH_01.Models.Student.PhotoPath));

            // then check validity
            if (ModelState.IsValid)
            {
                s.Id = ListStudents.Any() ? ListStudents.Max(x => x.Id) + 1 : 1;
                ListStudents.Add(s);
                return RedirectToRoute("StudentList");
            }

            // Collect ModelState errors to help debugging / show at top of form
            var errors = ModelState
                .Where(kvp => kvp.Value.Errors.Any())
                .Select(kvp => new
                {
                    Field = kvp.Key,
                    Messages = kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                })
                .ToList();

            // Log errors
            foreach (var e in errors)
            {
                _logger.LogWarning("ModelState error: {Field} => {Messages}", e.Field, string.Join(" | ", e.Messages));
            }

            // Pass errors to view so you can display them (optional)
            ViewBag.ModelErrors = errors;

            // Repopulate ViewBag data required by the form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };

            // Return same model so entered values and validation messages persist
            return View(s);
        }

        [HttpPost("Upload/{id}", Name = "UploadPhoto")]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(int id, IFormFile? photo)
        {
            if (photo == null || photo.Length == 0)
                return RedirectToRoute("StudentList");

            var student = ListStudents.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();

            var uploadsDir = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            var ext = Path.GetExtension(photo.FileName);
            var fileName = $"{Guid.NewGuid():N}{ext}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            student.PhotoPath = $"/uploads/{fileName}";

            return RedirectToRoute("StudentList");
        }
    }
}