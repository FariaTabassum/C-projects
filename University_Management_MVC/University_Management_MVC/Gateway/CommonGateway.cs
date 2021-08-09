using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace University_Management_MVC.Gateway
{
    public class CommonGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }
        public string SecondQuery { get; set; }
        public string SecondCommand { get; set; }

        private static string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManagementDBConnection"].ConnectionString;

        public CommonGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}