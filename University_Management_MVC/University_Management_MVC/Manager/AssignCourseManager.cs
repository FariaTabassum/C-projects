using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_MVC.Gateway;
using University_Management_MVC.Models;

namespace University_Management_MVC.Manager
{
    public class AssignCourseManager
    {
        AssignCourseGateway aAssignCourseGateway = new AssignCourseGateway();


        public List<Department> GetAllDepartments()
        {
            return aAssignCourseGateway.GetAllDepartments();
        }

        

       public List<Teacher> GetAllTeachers(int departmentId)
        {
           return aAssignCourseGateway.GetAllTeachers(departmentId);
        }
    }
}