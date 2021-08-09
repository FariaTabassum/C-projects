using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_MVC.Models;

namespace University_Management_MVC.Gateway
{
    public class AssignCourseGateway:CommonGateway
    {
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

        public List<Teacher> GetAllTeachers(int departmentId)
        {
            Query = "SELECT Name FROM Teacherstb where DepartmentId=@departmentId";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher
                {
                    TeacherId = (int)Reader["TeacherId"],
                    Name = Reader["Name"].ToString()
                };

                teachers.Add(teacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
    }
}