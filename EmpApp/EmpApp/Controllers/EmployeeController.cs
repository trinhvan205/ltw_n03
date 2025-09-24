using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpApp.Models;
namespace EmpApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult empList()
        {
            using (EmployeeEntities db = new EmployeeEntities())
            {
                var emplist = db.Employees.ToList();

                return View(emplist);
            }
        }
    }
}