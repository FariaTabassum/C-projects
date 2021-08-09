using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_MVC.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }


         //[Required(ErrorMessage = "Please insert Code first!")]
         //[StringLength(30,MinimumLength = 5, ErrorMessage = "Code at least 5 charachter long")]
         //[Display(Name = "Code:")]
         public string Code { get; set; }


         //[Required(ErrorMessage = "Please insert Name first!")]
         //[Display(Name = "Name:")]
         public string Name { get; set; }

         public float Credit { get; set; }


         //[Required(ErrorMessage = "Please insert Description first!")]
         //[Display(Name = "Description:")]


         public string Description { get; set; }
         //[Required(ErrorMessage = "Please select Department name first!")]
         //[Display(Name = "Department:")]
         public int DepartmentId { get; set; }



         //[Required(ErrorMessage = "Please select semester name first!")]
         //[Display(Name = "Semester:")]
          public int SemesterId { get; set; }
    }
}