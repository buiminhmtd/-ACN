using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules
{
    public partial class uc_Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            if (txtUsernameL.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Username not null !");
                txtUsernameL.Focus();
                return;
            }
            if (txtPasswordL.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Password not null !");
                txtUsernameL.Focus();
                return;
            }
            #endregion
            try
            {
                string passEncode = StringClass.Encrypt(txtPasswordL.Text);
                bool resultAd = CustomerService.Customer_CheckLogin(txtUsernameL.Text, passEncode);
                if (resultAd)
                {
                    Session["User"] = txtUsernameL.Text;
                    Session["Pass"] = txtPasswordL.Text;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    WebMsgBox.Show("Login fail");
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}