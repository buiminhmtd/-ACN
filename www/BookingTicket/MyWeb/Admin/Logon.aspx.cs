using System;
using MyWeb.Common;
using MyWeb.Business;

namespace MyWeb.Admin
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogon_Click(object sender, EventArgs e)
        {
            try
            {
                string passEncode = StringClass.Encrypt(txtPassword.Text);
                bool resultAd = AdminService.Admin_CheckLogin(txtUsername.Text, passEncode);
                if (resultAd)
                {
                    Session["Username"] = txtUsername.Text;
                    Session["Password"] = txtPassword.Text;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ltrError.Text = "Logon fail";
                }
            }
            catch (Exception ex)
            {
                ltrError.Text = ex.Message;
            }
        }
    }
}