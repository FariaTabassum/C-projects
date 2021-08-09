using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_MVC.Manager;

namespace University_Management_MVC.Controllers
{
    public class AssignCourseController : Controller
    {
        AssignCourseManager aAssignCourseManager = new AssignCourseManager();
        public ActionResult Index()
        {
            ViewBag.Departments =aAssignCourseManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(int departmentId, int teacherId,int CourseId)
        {
            ViewBag.Departments =aAssignCourseManager.GetAllDepartments();
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teachers = aAssignCourseManager.GetAllTeachers(departmentId);
            //var teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teachers);
        }
	}
}