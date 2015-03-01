using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using System.Data;


namespace SCMSWeb
{
     
    public partial class frmCreateNewCategory : System.Web.UI.Page
    {

        MainCategory catObj =new MainCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }



        public void LoadMainCat()
        {
            try
            {
                DataTable dt;
                catObj.TypeId = Convert.ToInt16(CboMainType.SelectedValue.ToString());
                dt = catObj.GetMainCat(catObj);

                if (dt.Rows.Count > 0)
                {
                    CboMainCategory.DataSource = dt;
                    CboMainCategory.DataTextField = "Type";
                    CboMainCategory.DataValueField = "TypeID";
                    CboMainCategory.DataBind();

                }
            }
            catch (Exception ex)
            {

            }




        }

      
        protected void CboMainType_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (CboMainType.Text != "")
            LoadMainCat(); 
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
           

        }

        protected void bntSave_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;

                dt = catObj.GetAllData();
                if (dt.Rows.Count > 0)
                {
                    DgvMainCat.DataSource = dt;
                    DgvMainCat.DataBind();

                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void DgvMainCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

       
       

    }
}