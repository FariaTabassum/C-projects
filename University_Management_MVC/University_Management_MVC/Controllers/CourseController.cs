using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_MVC.Manager;
using University_Management_MVC.Models;

namespace University_Management_MVC.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager = new CourseManager();
        public ActionResult Index()
        {
          
            ViewBag.Departments = aCourseManager.GetAllDepartments();
            ViewBag.Semesters = aCourseManager.GetAllSemesters();
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Course course)
        {
           
            ViewBag.Departments = aCourseManager.GetAllDepartments();
            ViewBag.Semesters = aCourseManager.GetAllSemesters();
            ViewBag.Message = aCourseManager.Save(course);

            return View();
        }


        private List<SelectListItem> GetDepartmentForDropDownList()
        {
            var departments = aCourseManager.GetAllDepartments();

            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem(){Value = "",Text="--Select Department"}
            };

            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = department.Id.ToString(),
                    Text = department.Name
                };
                items.Add(selectListItem);
            }
            ViewBag.Departments = items;
            return items;
        }

        private List<SelectListItem> GetSemesterForDropDownList()
        {
            var semesters = aCourseManager.GetAllSemesters();

            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem(){Value = "",Text="--Select Semester"}
            };

            foreach (var semester in semesters)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = semester.Id.ToString(),
                    Text = semester.Name
                };
                items.Add(selectListItem);
            }
            ViewBag.Semester = items;
            return items;
        }
        DepartmentManager departmentManager =new DepartmentManager();
        public ActionResult CourseStatics()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        public JsonResult GetAllCourseListByDeptId(int DepartmentId)
        {
            List<CourseStaticsViewModel> courseStatics = aCourseManager.GetAllCourseListByDeptId(DepartmentId);
            return Json(courseStatics, JsonRequestBehavior.AllowGet);
        }
	}
}