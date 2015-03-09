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

        Category catObj =new Category();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }



        public void LoadMainCat()
        {
            try
            {
                DataTable dt;
                catObj.TypeId = Convert.ToInt16(CboType.SelectedValue.ToString());
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
          if (CboType.Text != "")
            LoadMainCat(); 
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
           

        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    catObj.TypeId = Convert.ToInt16(CboType.SelectedValue);
                    catObj.MainCatID = Convert.ToInt16(CboMainCategory.SelectedValue);
                    catObj.Category1 = TxtCategory.Text;
                    catObj.Desc = TxtDescription.Text;


                    if (ChkActive.Checked == true)
                        catObj.Status = 1;
                    else
                        catObj.Status = 0;

                    if (catObj.InsertCategory(catObj))
                    {
                        LblMessage.Text = "Category successfully saved";
                        Clear();

                    }
                    else
                        LblMessage.Text = "Error occured opration";

                }
                catch (Exception ex)
                {
                    LblMessage.Text = ex.Message.ToString();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = catObj.GetAllData();
                DgvMainCat.DataSource = dt;
                DgvMainCat.DataBind();



            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

        protected void DgvMainCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageGrid(DgvMainCat.SelectedRow.Cells[2].Text.ToString());
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            TxtCategory.Text = "";
            TxtCatId.Text = "";
            TxtDescription.Text = "";
            DgvMainCat.DataSource = null;
        }

        public bool Validate()
        {
            if (TxtCategory.Text == "")
            {
                LblMessage.Text = "Please Enter  Category";
                return false;
            }
            else if (TxtDescription.Text == "")
            {
                LblMessage.Text = "Please Enter Description";
                return false;
            }
            else
                return true;

        }

        public void ManageGrid(String Category)
        {

            try
            {

                DataTable dt = catObj.GetCategoryByName(Category);
                if (dt.Rows.Count > 0)
                {
                    CboMainCategory.SelectedValue = dt.Rows[0]["TypeID"].ToString();
                    TxtCatId.Text = dt.Rows[0]["CatID"].ToString();
                    TxtCategory.Text = dt.Rows[0]["Category"].ToString();
                    TxtDescription.Text = dt.Rows[0]["Description"].ToString();
                    if (Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString()) == true)
                    {
                        ChkActive.Checked = true;
                    }
                    else
                    {
                        ChkActive.Checked = false;
                    }

                }


            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

      

       
       

    }
}