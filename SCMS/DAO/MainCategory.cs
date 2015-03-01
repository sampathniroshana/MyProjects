using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace DAO
{
    public class MainCategory 
    {

        private int typeId;
        public MainCatDal mainCatDal = new MainCatDal();


        public int TypeId
        {
          get { return typeId; }
          set { typeId = value; }
        }


        public DataTable GetMainCat(MainCategory obj)
        {
            DataTable Dt = mainCatDal.GetMainCategory(obj.typeId);
            if (Dt.Rows.Count > 0)
                return Dt;
            else
                return null;
            
        }


        public DataTable GetAllData()
        {
            DataTable Dt = mainCatDal.GetAllData();
            if (Dt.Rows.Count > 0)
                return Dt;
            else
                return null;

        }
    }
}
