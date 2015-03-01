using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace SCMSWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {

                UserLogin(txtUserName.Text, txtPassword.Text);
            }
            catch (Exception ex)
            {
               // actionLog.Error(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }


        }

        public void UserLogin(String uName, String pWord)
        {
            LoginUser loginUser = new LoginUser();
            loginUser.UserName = uName;
            loginUser.Password = pWord;

            if (loginUser.getUser(loginUser))
            {
                Session["username"] = uName;
                Response.Redirect("agentDashboad.aspx");
                
               
            }
           
               
//

        }
    }
}