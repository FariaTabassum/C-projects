using StockManagementSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Gateway
{
    public class CategoryGateway : Gateway
    {
        internal bool IsNameExists(Model.Category aCategory)
        {
            Query = "select * from CatagorySetup where Name='" + aCategory.Name +
                           "' AND ID <>" + aCategory.Id;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        internal int Save(Model.Category aCategory)
        {
            Query = "Insert into CatagorySetup values('" + aCategory.Name + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        internal List<Model.Category> GetAllCategory()
        {
            Query = "Select * from CatagorySetup";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Category> categorys = new List<Category>();

            while (Reader.Read())
            {
                Category aCategory = new Category();
                aCategory.Id = (int)Reader["Id"];
                aCategory.Name = Reader["Name"].ToString();

                categorys.Add(aCategory);
            }
            Reader.Close();
            Connection.Close();
            return categorys;
        }

        internal int Update(Category aCategory)
        {
            Query = "UPDATE CatagorySetup SET Name='" + aCategory.Name +
               "' WHERE Id = " + aCategory.Id;

            Connection.Open();

            Command = new SqlCommand(Query, Connection);

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }
    }
}