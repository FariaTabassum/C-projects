using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_MVC.Controllers;
using University_Management_MVC.Models;

namespace University_Management_MVC.Gateway
{
    public class CourseGateway: CommonGateway
    {

        public bool IsCourseCodeExits(string code)
        {
           
            Query = "SELECT * FROM Coursestb where Code=@Code";
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

        public bool IsCourseNameExits(string name)
        {
          
            Query = "SELECT * FROM Coursestb where Name=@Name";
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

        public List<Semester> GetAllSemesters()
        {
            Query = "SELECT * FROM Semesterstb";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (Reader.Read())
            {
                Semester semester = new Semester
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };

                semesters.Add(semester);
            }
            Reader.Close();
            Connection.Close();
            return semesters;
        }

        public int Save(Course course)
        {
          
            Query = "INSERT INTO Coursestb VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@Code", course.Code);
            Command.Parameters.AddWithValue("@Name", course.Name);
            Command.Parameters.AddWithValue("@Credit", course.Credit);
            Command.Parameters.AddWithValue("@Description", course.Description);
            Command.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
            Command.Parameters.AddWithValue("@SemesterId", course.SemesterId);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<CourseStaticsViewModel> GetAllCourseListByDeptId(int departmentId)
        {
            string query =
                "SELECT Course.CourseCode AS CourseCode, Course.CourseName AS CourseName, Semester.SemesterName AS Semester, Teacher.Name AS AssignedTeacherName From Course LEFT JOIN Departments ON  Course.DeptId = Departments.DeptId LEFT JOIN Semester on Semester.SemesterId = Course.SemesterId LEFT JOIN CourseAssignToTeacher on Course.CourseId = CourseAssignToTeacher.CourseId LEFT JOIN Teacher on Teacher.TeacherId = CourseAssignToTeacher.TeacherId AND CourseAssignToTeacher.Action=@insert WHERE Departments.DeptId = @departmentId ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@insert", "insert");
            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStaticsViewModel> courseStaticList = new List<CourseStaticsViewModel>();
            while (Reader.Read())
            {
                CourseStaticsViewModel aCourseStatics = new CourseStaticsViewModel();
                aCourseStatics.CourseCode = Reader["CourseCode"].ToString();
                aCourseStatics.CourseName = Reader["CourseName"].ToString();
                aCourseStatics.Semester = Reader["Semester"].ToString();
                string assignto = Reader["AssignedTeacherName"].ToString();
                if (string.IsNullOrEmpty(assignto))
                {
                    aCourseStatics.AssignedTeacherName = "Not Assigned yet";
                }
                else
                {
                    aCourseStatics.AssignedTeacherName = Reader["AssignedTeacherName"].ToString();

                }
                courseStaticList.Add(aCourseStatics);
            }
            Reader.Close();
            Connection.Close();
            return courseStaticList;
        }
    }
}