using StockManagementSystem.DAL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();

        internal string Save(DAL.Model.Category aCategory)
        {
            if (aCategoryGateway.IsNameExists(aCategory))
            {
                return "Name already exists";
            }
            int rowAffacted = aCategoryGateway.Save(aCategory);
            if (rowAffacted > 0)
            {
                return "";
            }
            else
            {
                return " Saved Failed";
            }
        }

        internal List<DAL.Model.Category> GetAllCatagory()
        {
            return aCategoryGateway.GetAllCategory();
        }



        internal string Update(DAL.Model.Category aCategory)
        {
            if (aCategoryGateway.IsNameExists(aCategory))
            {
                return "ISBN already exists";
            }
            int rowAffacted = aCategoryGateway.Update(aCategory);
            if (rowAffacted > 0)
            {
                return "Book info Updated Successfully";
            }
            else
            {
                return " Updated Failed";
            }
        }
    }
}