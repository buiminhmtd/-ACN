using System;

namespace MyWeb.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lbFullName.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("Logon.aspx");
            }
        }

        protected void lbtOut_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Response.Redirect("Logon.aspx");
        }
    }
}