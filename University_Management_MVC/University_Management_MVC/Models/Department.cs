using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_MVC.Models
{
    public class Department
    {
        public int Id {get;set;}
        public string Code { get; set; }
        public string Name { get; set; }
        
 
        //public int Id { get; set; }

        ////[Required(ErrorMessage = "Please insert Code first!")]
        ////[StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be between 2 to 7 charachter")]
        //public string Code { get; set; }

        ////[Required(ErrorMessage = "Please insert name first!")]
        //public string Name { get; set; }
    }
}