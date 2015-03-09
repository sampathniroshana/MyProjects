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
    public partial class ManageUserGroups : System.Web.UI.Page
    {
        UserInfo objUser = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadUserList();
                loadUserGroupList();
            }
        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    objUser.UserGroupName = TxtUserGroup.Text;
                    objUser.UName = CboAgent.SelectedItem.ToString();
                    objUser.UserGrouDesc = TxtDescription.Text;
                    objUser.Distribution = CboDistribution.SelectedItem.ToString();

                    if (ChkActive.Checked == true)
                        objUser.Status = 1;
                    else
                        objUser.Status = 0;

                    if (objUser.SaveUserGroupDetails(objUser))
                    {
                        if(CboAgent.Text != "")
                        {
                        objUser.SaveUserGroupWithUsers(objUser);
                        }
                        LblMessage.Text = "User Group successfully saved";
                        Clear();

                    }
                    else
                        LblMessage.Text = "Error occured opretion";

                }
                catch (Exception ex)
                {
                    LblMessage.Text = ex.Message.ToString();
                }
            }
        }

        public bool Validate()
        {
            if (TxtUserGroup.Text == "")
            {
                LblMessage.Text = "Please Enter User Group Name";
                return false;
            }
            else if (TxtDescription.Text == "")
            {
                LblMessage.Text = "Please Enter Description ";
                return false;
            }
            else if (CboDistribution.Text == "")
            {
                LblMessage.Text = "Please Select Distribution Method ";
                return false;
            }
            
           
            else
                return true;

        }


        public void Clear()
        {
            TxtUserGroupID.Text = "";
            TxtUserGroup.Text = "";
            TxtDescription.Text = "";
            CboDistribution.Text = "";
            LblMessage.Text = "";
            DgvGroups.DataSource = null;
            DgvGroups.DataBind();
            loadUserList();
            loadUserGroupList();

        }

        public void loadUserList()
        {
            try
            {

                DataTable dt = objUser.GetAllusers();
                if (dt.Rows.Count > 0)
                {
                    CboAgent.DataSource = dt;
                    CboAgent.DataTextField = "Username";
                    CboAgent.DataValueField = "UserID";
                    CboAgent.DataBind();
                    
                }


            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }


    public void loadUserGroupList()
        {
            try
            {

                DataTable dt = objUser.GetAlluserGroups();
                if (dt.Rows.Count > 0)
                {
                    DgvGroups.DataSource = dt;
                    DgvGroups.DataBind();
                    
                }


            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

    public void ManageGrid(String userName)
    {

        try
        {

            DataTable dt = objUser.GetUserGroupByName(userName);
            if (dt.Rows.Count > 0)
            {
                TxtUserGroupID.Text = dt.Rows[0]["GroupID"].ToString();
                TxtUserGroup.Text = dt.Rows[0]["GroupName"].ToString();
                TxtDescription.Text = dt.Rows[0]["Description"].ToString();
                CboDistribution.Text = dt.Rows[0]["Distribution"].ToString();
               
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

    protected void DgvGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        ManageGrid(DgvGroups.SelectedRow.Cells[0].Text.ToString());
    }
    

        }
    
}