using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    public class RegisterController : Controller
    {
        StudentDbContext dc=new StudentDbContext();
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {
            // ModelState keeps track of the state of the model binding and validation. It tells you:

            //Which form fields were successfully bound to your model.

             //Which fields failed validation.

             //Any error messages associated with those fields.
            if (ModelState.IsValid)
            {
                student.Status=true;
                student.Role = "Student";
                dc.Students.Add(student);
                dc.SaveChanges();

                Session["Name"]=student.Name;
                Session["DOB"] = student.DateOfBirth;
                Session["Role"] = student.Role;
                return RedirectToAction("Login");
            }
            
            return View(student);
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Name,DateTime DateOfBirth)
        {
           var user=dc.Students.FirstOrDefault(s=>s.Name==Name&&s.DateOfBirth==DateOfBirth);
            if (user!=null)
            {
                Session["Name"] = user.Name;
                Session["DateOfBirth"]=user.DateOfBirth;
                Session["Role"] = user.Role;
                if (user.Role == "Admin")
                    return RedirectToAction("Dashboard", "Admin");
                else
                {
                    return RedirectToAction("Home", "Student"); 
                }
            }
            ModelState.AddModelError("", "Invalid Name or DOB");
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }



    }
}