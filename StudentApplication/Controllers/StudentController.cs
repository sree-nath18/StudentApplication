using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApplication.Filters;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    [AuthenticationFilter]
    public class StudentController : Controller
    {
        // GET: Student
        StudentDbContext dc = new StudentDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Home()
        {
            return View();
        }
        public ViewResult Profile()
        {
            var Name = Convert.ToString(Session["Name"]);
            var DateOfBirth = Convert.ToDateTime(Session["DateOfBirth"]);
            if (Name == null&&DateOfBirth==null)
            {
                RedirectToAction("Login", "Register");
            }
            var student = dc.Students.FirstOrDefault(s => s.Name == Name && s.DateOfBirth == DateOfBirth);
            return View(student);
        }
        public ViewResult Examinations()
        {
            return View();
        }
        public ViewResult Events()
        {
            return View();
        }
        public ViewResult About()
        {
            return View();
        }

    }
}