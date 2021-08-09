using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_MVC.Gateway;
using University_Management_MVC.Models;

namespace University_Management_MVC.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public List<Designation> GetAllDesignations()
        {
            return aTeacherGateway.GetAllDesignations();
        }

        public List<Department> GetAllDepartments()
        {
            return aTeacherGateway.GetAllDepartments();
        }

        public string Save(Teacher teacher)
        {
            if (aTeacherGateway.IsEmailExits(teacher.Email))
            {
                return "Sorry,email already exists";
            }

            else
            {
                int rowAffected = aTeacherGateway.Save(teacher);
                if (rowAffected > 0)
                {
                    return "Infromation save successfully";
                }
                return "Information faield to save";
            }
        }
    }
}