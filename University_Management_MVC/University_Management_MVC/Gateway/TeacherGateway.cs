using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_MVC.Models;

namespace University_Management_MVC.Gateway
{
    public class TeacherGateway:CommonGateway
    {

        public bool IsEmailExits(string email)
        {
            Query = "SELECT * FROM Teacherstb where Email=@Email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Email", email);
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

        public List<Designation> GetAllDesignations()
        {


            Query = "SELECT * FROM Designationstb";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (Reader.Read())
            {
                Designation designation = new Designation
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };

                designations.Add(designation);
            }
            Reader.Close();
            Connection.Close();
            return designations;
        }

        public List<Department> GetAllDepartments()
        {


            Query = "SELECT * FROM Departmentstb";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };

                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public int Save(Teacher teacher)
        {
            Query = "INSERT INTO Teacherstb VALUES(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditToBeTaken)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("@Name", teacher.Name);
            Command.Parameters.AddWithValue("@Address", teacher.Address);
            Command.Parameters.AddWithValue("@Email", teacher.Email);
            Command.Parameters.AddWithValue("@ContactNo", teacher.ContactNo);
            Command.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@CreditToBeTaken", teacher.CreditToBeTaken);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

    }
}