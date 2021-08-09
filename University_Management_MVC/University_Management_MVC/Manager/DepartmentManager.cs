using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_MVC.Gateway;
using University_Management_MVC.Models;

namespace University_Management_MVC.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
       
        public string Save(Models.Department department)
        {
            if (aDepartmentGateway.IsNameExits(department.Name))
            {
                return "Sorry,Department name already exists";
            }
            else if(aDepartmentGateway.IsCodeExits(department.Code))
            {
                return "Sorry,Department code already exists";
            }
            else
            {
                int rowAffected = aDepartmentGateway.Save(department);
                if (rowAffected > 0)
                {
                    return "Infromation save successfully";
                }
                return "Information faield to save";
            }
        }

        //public List<Department> GetDepartments(Department department)
        //{
        //    return aDepartmentGateway.GetDepartments(department);
        //}
        public object GetAllDepartmentForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });
            foreach (Department department in GetAllDepartments())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        private List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }
    }
}