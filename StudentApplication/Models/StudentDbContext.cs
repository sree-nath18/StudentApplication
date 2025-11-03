using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Security.Cryptography.X509Certificates;

namespace StudentApplication.Models
{
    public class StudentDbContext: DbContext

    {
        public StudentDbContext():base("ConStr")
        {
            Database.SetInitializer(new DbInitialiser());  
        }
        public DbSet<Student> Students { get; set; }
      
    }
}