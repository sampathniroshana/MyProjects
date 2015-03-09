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
    public partial class ManageCategory : System.Web.UI.Page
    {

        Category catObj = new Category();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      
        protected void bntSave_Click(object sender, EventArgs e)
        {
            //Save main category to DB

            if (Validate())
            {
                try
                {
                    catObj.TypeId = Convert.ToInt16(CboMainType.SelectedValue);
                    catObj.MainCat = TxtMainCat.Text;
                    catObj.Desc = TxtDescription.Text;


                    if (ChkActive.Checked == true)
                        catObj.Status = 1;
                    else
                        catObj.Status = 0;

                    if (catObj.InsertMainCategory(catObj))
                        LblMessage.Text = "Main category successfully saved";
                    else
                        LblMessage.Text = "Error occured opration";

                }
                catch (Exception ex)
                {
                    LblMessage.Text = ex.Message.ToString();
                }
            }
        }

        public bool Validate()
        {
            if (TxtMainCat.Text == "")
            {
                LblMessage.Text = "Please Enter Main Category";
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

        public void Clear()
        {
            TxtDescription.Text = "";
            TxtMainCat.Text = "";
            DgvMainCat.DataSource = null;
            DgvMainCat.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try {
                DataTable dt = catObj.GetAllMainCategory();
                DgvMainCat.DataSource = dt;
                DgvMainCat.DataBind();

                
           
            }catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

        public void ManageGrid(String mainCat)
        {

            try
            {

                DataTable dt = catObj.GetAllMainCategoryByName(mainCat);
               if (dt.Rows.Count >0)
               {
                   CboMainType.SelectedValue =dt.Rows[0]["InteractionTypeID"].ToString();
                   TxtMainCatID.Text = dt.Rows[0]["TypeID"].ToString();
                   TxtMainCat.Text = dt.Rows[0]["Type"].ToString();
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

        protected void DgvMainCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageGrid(DgvMainCat.SelectedRow.Cells[1].Text.ToString());
           
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        
    }
}