using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        //[Required(ErrorMessage = "Please insert Name first!")]
        //[Display(Name = "Name:")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please insert Address first!")]
        //[Display(Name = "Address:")]
        public string Address { get; set; }
        
        public string Email { get; set; }


        public int ContactNo { get; set; }

        //[Required(ErrorMessage = "Please select designation Name first!")]
        //[Display(Name = "Designation:")]
        public int DesignationId { get; set; }

        //[Required(ErrorMessage = "Please select department name first!")]
        //[Display(Name = "Department:")]
        public int DepartmentId { get; set; }

        public int CreditToBeTaken { get; set; }
    }
}