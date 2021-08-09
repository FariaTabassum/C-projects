using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_MVC.Controllers;
using University_Management_MVC.Gateway;
using University_Management_MVC.Models;

namespace University_Management_MVC.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();

        public List<Department> GetAllDepartments()
        {
            return aCourseGateway.GetAllDepartments();
        }

        public List<Semester> GetAllSemesters()
        {
            return aCourseGateway.GetAllSemesters();
        }

        public string Save(Course course)
        {
            if (aCourseGateway.IsCourseCodeExits(course.Code))
            {
                return "Sorry,Department code already exists";
            }
            else if (aCourseGateway.IsCourseNameExits(course.Name))
            {
                return "Sorry,Course name already exists";
            }
            else
            {
                int rowAffected = aCourseGateway.Save(course);
                if (rowAffected > 0)
                {
                    return "Infromation save successfully";
                }
                return "Information faield to save";
            }
        }

        public List<CourseStaticsViewModel> GetAllCourseListByDeptId(int departmentId)
        {
            return aCourseGateway.GetAllCourseListByDeptId(departmentId);
        }
    }
}