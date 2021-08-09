using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
//using ShowAjaxcall.Models;
using University_Management_MVC.Manager;
using University_Management_MVC.Models;
using University_Management_MVC.Gateway;
using System.Configuration;

namespace University_Management_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Department department)
        {
            
            ViewBag.Message = aDepartmentManager.Save(department);
            return View();
        }

       

        //public JsonResult GetDepartmentDatatable(Department department)
        //{
        //    var departments = aDepartmentManager.GetDepartments(department);
        //    return Json(departments);
        //}

        //public JsonResult get_data()
        //{
        //    DataSet ds = aDepartmentGateway.Show_data();
        //    List<Department> listdept=new List<Department>();
        //    foreach(DataRow dr in ds.Tables[0].Rows)
        //    {
        //        listdept.Add(new Department
        //        {
        //             Id=Convert.ToInt32(dr["Id"]),
        //             Code=dr["Code"].ToString(),
        //             Name=dr["Name"].ToString()
        //        });
               
        //    }
        //    return Json(listdept, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult PopulatedData()
        {
            SqlConnection Con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings["UniversityManagementDBConnection"].ConnectionString;
            Con.ConnectionString = path;
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from Departmentstb", Con);
                adp.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return View(dt);
        }


	}
}