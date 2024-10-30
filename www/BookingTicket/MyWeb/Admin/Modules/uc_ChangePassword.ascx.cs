using System;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admin.Modules
{
    public partial class uc_ChangePassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtUpdateT_Click(object sender, EventArgs e)
        {
            string PassEncode = StringClass.Encrypt(txtNewPassword.Text);
            #region[TestInput]
            if (txtCurrentPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Current Password not null !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtCurrentPassword.Text != Session["Password"].ToString())
            {
                WebMsgBox.Show("Current Password error !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("New Password not null !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtReenterPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Reenter Password not null  !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtNewPassword.Text != txtReenterPassword.Text)
            {
                WebMsgBox.Show("Password not same!");
                txtNewPassword.Focus();
                return;
            }
            #endregion

            try
            {
                AdminService.Admin_ChangePassword(Session["Username"].ToString(), PassEncode);
                WebMsgBox.Show("Change password success");
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtUpdateB_Click(object sender, EventArgs e)
        {
            string PassEncode = StringClass.Encrypt(txtNewPassword.Text);
            #region[TestInput]
            if (txtCurrentPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Current Password not null !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtCurrentPassword.Text != Session["Password"].ToString())
            {
                WebMsgBox.Show("Current Password error !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("New Password not null !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtReenterPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Reenter Password not null  !");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtNewPassword.Text != txtReenterPassword.Text)
            {
                WebMsgBox.Show("Password not same!");
                txtNewPassword.Focus();
                return;
            }
            #endregion

            try
            {
                AdminService.Admin_ChangePassword(Session["Username"].ToString(), PassEncode);
                WebMsgBox.Show("Change password success");
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}