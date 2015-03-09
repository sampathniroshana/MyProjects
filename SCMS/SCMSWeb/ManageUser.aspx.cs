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
    
    public partial class ManageUser : System.Web.UI.Page
    {
        UserInfo objUser = new UserInfo();
     

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    objUser.UName = TxtUserName.Text;
                    objUser.Password = Txtpassword.Text;
                    objUser.Email = TxtEmail.Text;
                    objUser.UserMode = CboUserType.SelectedItem.ToString();




                    if (ChkActive.Checked == true)
                        objUser.Status = 1;
                    else
                        objUser.Status = 0;

                    if (objUser.SaveUserDetails(objUser))
                    {
                        LblMessage.Text = "User successfully saved";
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


        public void Clear()
        {
            TxtUserName.Text = "";
            Txtpassword.Text = "";
            TxtuserID.Text = "";
            TxtEmail.Text = "";
            TxtCpassword.Text = "";
            DgvUser.DataSource = null;
            DgvUser.DataBind();

        }

        public bool Validate()
        {
            if (TxtUserName.Text == "")
            {
                LblMessage.Text = "Please Enter User Name";
                return false;
            }
            else if (Txtpassword.Text == "")
            {
                LblMessage.Text = "Please Enter Password ";
                return false;
            }
            else if (TxtCpassword.Text == "")
            {
                LblMessage.Text = "Please Re-enter Password ";
                return false;
            }
            else if (TxtEmail.Text == "")
            {
                LblMessage.Text = "Please Enter Email address ";
                return false;
            }
            else
                return true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                objUser.UserMode = CboUserType.SelectedItem.ToString();
                DataTable dt = objUser.GetUserData(objUser);
                DgvUser.DataSource = dt;
                DgvUser.DataBind();



            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message.ToString();
            }
        }

        protected void DgvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageGrid(DgvUser.SelectedRow.Cells[1].Text.ToString());
        }

        public void ManageGrid(String userName)
        {

            try
            {

                DataTable dt = objUser.GetUserByName(userName);
                if (dt.Rows.Count > 0)
                {
                    TxtuserID.Text = dt.Rows[0]["UserID"].ToString();
                    TxtUserName.Text = dt.Rows[0]["Username"].ToString();
                    Txtpassword.Text = dt.Rows[0]["Password"].ToString();
                    TxtCpassword.Text = dt.Rows[0]["Password"].ToString();
                    TxtEmail.Text = dt.Rows[0]["Email"].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

    }
}