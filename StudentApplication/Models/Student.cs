using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentApplication.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }

        [Required (ErrorMessage ="Name is required")]
        [MinLength(4,ErrorMessage ="Minimum 4 characters required")]
        [MaxLength(100,ErrorMessage ="Maximum 100 characters are allowed")]
        [Column("Name",TypeName ="varchar")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FatherName is required")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Column("FatherName", TypeName = "varchar")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "MotherName is required")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Column("MotherName", TypeName = "varchar")]
        public string MotherName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="DateOfBirth is required")]
        [Column("DOB")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage ="This Field Cannot be Left Empty")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Class is required")]
        public int Class { get; set; }

        public bool Status { get; set; }=true;

        public string Role { get; set; } = "Student";

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[6-9]{1}[0-9]{9}",ErrorMessage = "the Mobile Number should start with 6,7,8 or 9 and should be of 10 digits")]
        [Required(ErrorMessage ="MobileNo is required")]
        public string MobileNo { get; set; }


        [DataType(DataType.EmailAddress)]        
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }




    }
}