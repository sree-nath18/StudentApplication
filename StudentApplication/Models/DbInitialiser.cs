using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentApplication.Models
{
    public class DbInitialiser:DropCreateDatabaseAlways<StudentDbContext>
    {
        
        protected override void Seed(StudentDbContext context)
        {

            Student s1 = new Student
            {
                Name = "Admin",
                FatherName = "Father",
                MotherName = "Mother",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = "Gender",
                Class = 0,
                MobileNo = "9012212223",
                Role = "Admin",
              Email = "Admin@123",
                Address = "Hyderabad"
            };
            context.Students.Add(s1);
            
            base.Seed(context);
        }
    }
}