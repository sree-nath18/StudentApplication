using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Models
{
    public class AdminController : Controller
    {
        // GET: Admin
         StudentDbContext dc=new StudentDbContext();
        public ViewResult Dashboard()
        {
            var student = dc.Students.Where(S=>S.Status==true);
            return View(student);
        }
        public ViewResult DisplayStudent(int Sid)
        {
            var student = dc.Students.Find(Sid);
            return View(student);
        }
        public ViewResult EditStudent(int Sid)
        {
            var student = dc.Students.Find(Sid);
            if (Session["DateOfBirth"] != null)
            {
                // Check the type of Session["DateOfBirth"]
                if (Session["DateOfBirth"] is DateTime)
                {
                    student.DateOfBirth = (DateTime)Session["DateOfBirth"];
                }
            }
           
            return View(student);

        }
        public RedirectToRouteResult UpdateStudent(Student student)
        {
            student.Status = true;
           dc.Entry(student).State=System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("Dashboard"); 
        }
        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            var student = dc.Students.Find(Sid);
            student.Status = false;
            dc.Entry(student).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("Dashboard");            

        }
    }
}