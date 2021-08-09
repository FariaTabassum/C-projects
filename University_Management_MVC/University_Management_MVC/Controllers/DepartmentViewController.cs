using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Configuration;

namespace University_Management_MVC.Controllers
{
    public class DepartmentViewController : Controller
    {
        
       


        public ActionResult Index()
        {
            SqlConnection Con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings["UniversityManagementDBConnection"].ConnectionString;
            Con.ConnectionString = path;
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select code,name from Departmentstb", Con);
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