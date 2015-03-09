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
    public partial class ManageSubCategory : System.Web.UI.Page
    {
        Category catObj = new Category();
        UserInfo objUser = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                LoadMainCat();
                LoadUserGroupList();
            }
            

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
                    CboMainCat.DataSource = dt;
                    CboMainCat.DataTextField = "Type";
                    CboMainCat.DataValueField = "TypeID";
                    CboMainCat.DataBind();

                }
                else
                {
                    CboMainCat.DataSource = dt;
                    CboMainCat.DataTextField = "Type";
                    CboMainCat.DataValueField = "TypeID";
                    CboMainCat.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }

        }

        public void LoadCategory()
        {
            try
            {
                DataTable dt;

                catObj.MainCatID = Convert.ToInt16(CboMainCat.SelectedValue.ToString());
                dt = catObj.GetCategoryByMaincat(catObj);

                if (dt.Rows.Count > 0)
                {
                    CboCategory.DataSource = dt;
                    CboCategory.DataTextField = "Category";
                    CboCategory.DataValueField = "CatID";
                    CboCategory.DataBind();

                }
                else
                {
                    CboCategory.DataSource = dt;
                    CboCategory.DataTextField = "Category";
                    CboCategory.DataValueField = "CatID";
                    CboCategory.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }

        }

        protected void CboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMainCat();
        }

        protected void CboMainCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategory();
        }

        public void LoadUserGroupList()
        {
            try
            {

                DataTable dt = objUser.GetAlluserGroups();
                if (dt.Rows.Count > 0)
                {

                    CboUserGroup.DataSource = dt;
                    CboUserGroup.DataTextField = "GroupName";
                    CboUserGroup.DataValueField = "GroupID";
                    CboUserGroup.DataBind();

                }


            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    catObj.CatID = Convert.ToInt16(CboCategory.SelectedValue);
                    catObj.SubCat = TxtSubcat.Text;
                    catObj.Desc = TxtDesc.Text;
                    catObj.UGrouoId = Convert.ToInt16(CboUserGroup.SelectedValue);
                    


                    if (ChkStatus.Checked == true)
                        catObj.Status = 1;
                    else
                        catObj.Status = 0;

                    if (catObj.InsertSubCategory(catObj))
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


        public void Clear()
        {
            TxtSubcatID.Text = "";
            TxtSubcat.Text = "";
            TxtDesc.Text = "";
            DgvSubCat.DataSource = null;
            DgvSubCat.DataBind();
        }

        public bool Validate()
        {
            if (TxtSubcat.Text == "")
            {
                LblMessage.Text = "Please Enter Sub Category";
                return false;
            }
            else if (TxtDesc.Text == "")
            {
                LblMessage.Text = "Please Enter Description";
                return false;
            }
            else if (CboUserGroup.Text == "")
            {
                LblMessage.Text = "Please Select User Group";
                return false;
            }
            else
                return true;

        }

        public void ManageGrid(String sCategory)
        {

            try
            {

                DataTable dt = catObj.GetSubCategoryByName(sCategory);
                if (dt.Rows.Count > 0)
                {
                    
                    TxtSubcatID.Text = dt.Rows[0]["CatID"].ToString();
                    TxtSubcat.Text = dt.Rows[0]["SubCategory"].ToString();
                    TxtDesc.Text = dt.Rows[0]["Description"].ToString();
                    CboUserGroup.SelectedValue = dt.Rows[0]["AssignedGroup"].ToString();
                    if (Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString()) == true)
                    {
                        ChkStatus.Checked = true;
                    }
                    else
                    {
                        ChkStatus.Checked = false;
                    }

                }


            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

        protected void DgvSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageGrid(DgvSubCat.SelectedRow.Cells[3].Text.ToString());
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                catObj.CatID = Convert.ToInt16(CboCategory.SelectedValue);
                DataTable dt = catObj.GetAllDataWithSubCat(catObj);
                DgvSubCat.DataSource = dt;
                DgvSubCat.DataBind();



            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        }

    
}