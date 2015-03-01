using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCMSWeb
{
    public partial class Agent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUserName.Text = "Welcome " + Session["username"];

            }
        }

        protected void lnkbtnLogin_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Login.aspx");
            
        }
    }
}