using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using University_Management_MVC.Models;
using System.Web.Mvc;

namespace University_Management_MVC.Gateway
{
    public class DepartmentGateway : CommonGateway
    {
        public bool IsNameExits(string name)
        {
            Query = "SELECT * FROM Departmentstb where Name = @Name";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", name);
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public int Save(Models.Department department)
        {
            Query = "INSERT INTO Departmentstb VALUES(@Code,@Name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@Code", department.Code);
            Command.Parameters.AddWithValue("@Name", department.Name);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }



        //public List<Department> GetDepartments(Department department)
        //{
        //    Query = "select Code,Name from Departmentstb where Id=@Id";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.Clear();
        //    Command.Parameters.AddWithValue("@Code", department.Code);
        //    Command.Parameters.AddWithValue("@Name", department.Name);
        //    Connection.Open();
        //    SqlDataReader Reader = Command.ExecuteReader();
        //    List<Department> departments = new List<Department>();

        //    while (Reader.Read())
        //    {

        //        Department aDepartment = new Department()
        //        {
        //            Id = (int)Reader["Id"],
        //            Code = Reader["Code"].ToString(),
        //            Name = Reader["Name"].ToString(),

        //        };
        //        departments.Add(aDepartment);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return departments;
        //}




        //public DataSet Show_data()
        //{
        //    Query = "Select * from Departmentstb";
        //    Command = new SqlCommand(Query, Connection);
        //    SqlDataAdapter da = new SqlDataAdapter(Command);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;
        //}



        public bool IsCodeExits(string code)
        {
            Query = "SELECT * FROM Departmentstb where Code = @Code";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Code", code);
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public List<Department> GetAllDepartments()
        {
           string query = "SELECT * FROM Departmentstb";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Department> departmentList = new List<Department>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = Convert.ToInt32(Reader["Id"]);
                aDepartment.Code = Reader["Code"].ToString();
                aDepartment.Name = Reader["Name"].ToString();
                departmentList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departmentList;

        }
        
    }
}