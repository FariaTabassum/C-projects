using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_MVC.Manager;
using University_Management_MVC.Models;

namespace University_Management_MVC.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager aTeacherManager = new TeacherManager();
        public ActionResult Index()
        {
            //var designation = GetDesignationForDropDownList();
            //ViewBag.Designations = designation;

            //var department = GetDepartmentForDropDownList();
            //ViewBag.Departments = department;

            ViewBag.Designations = aTeacherManager.GetAllDesignations();
                ViewBag.Departments = aTeacherManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            //var designation = GetDesignationForDropDownList();
            //ViewBag.Designations = designation;

            //var department = GetDepartmentForDropDownList();
            //ViewBag.Departments = department;
            ViewBag.Designations = aTeacherManager.GetAllDesignations();
            ViewBag.Departments = aTeacherManager.GetAllDepartments();
            ViewBag.Message = aTeacherManager.Save(teacher);

            return View();
        }


        private List<SelectListItem> GetDepartmentForDropDownList()
        {
            var departments = aTeacherManager.GetAllDepartments();

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

        private List<SelectListItem> GetDesignationForDropDownList()
        {
            var designations = aTeacherManager.GetAllDesignations();

            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem(){Value = "",Text="--Select Designation"}
            };

            foreach (var designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = designation.Id.ToString(),
                    Text = designation.Name
                };
                items.Add(selectListItem);
            }
            ViewBag.Designations = items;
            return items;
        }


	}
}