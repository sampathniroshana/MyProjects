using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DAL
{
    public class MainCatDal: DataAccess
    {


        DataTable dt;
        

     
        public DataTable GetMainCategory(int id)
        {
            try
            {
                string sql = "";
                DataSet dt;
                sql = "SELECT  TypeID,Type FROM CIA_Type where  InteractionTypeID = '" + id + "'";
                dt = getDataset(sql);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetAllData()
        {
            try
            {
                string sql = "";
                DataSet dt;
                sql = " SELECT     CIA_InteractionType.InteractionType, CIA_Type.Type "+
                        "FROM         CIA_Type INNER JOIN " +
                       "CIA_InteractionType ON CIA_Type.InteractionTypeID = CIA_InteractionType.InteractionTypeID";
                dt = getDataset(sql);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    
    }
}
