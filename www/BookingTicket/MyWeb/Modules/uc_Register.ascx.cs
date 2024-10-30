using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Modules
{
    public partial class uc_Register : System.Web.UI.UserControl
    {
        Regex reg = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            string passEncode = StringClass.Encrypt(txtPassword.Text);
            #region[TestInput]
            if (txtUsername.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Username not null !");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Password not null !");
                txtUsername.Focus();
                return;
            }
            if (txtReenterPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Reenter Password not null !");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text != txtReenterPassword.Text)
            {
                WebMsgBox.Show("Password not same !");
                txtUsername.Focus();
                return;
            }
            if (txtCard.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Credit Card not null !");
                txtCard.Focus();
                return;
            }
            if (txtName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Full Name not null !");
                txtName.Focus();
                return;
            }
            if (txtBirth.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birth not null !");
                txtBirth.Focus();
                return;
            }
            if (txtAddress.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Address not null !");
                txtAddress.Focus();
                return;
            }
            if (txtPhone.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Phone not null !");
                txtPhone.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Email  !");
                txtEmail.Focus();
                return;
            }
            if (!reg.IsMatch(txtEmail.Text))
            {
                WebMsgBox.Show("Not a valid email!");
                txtEmail.Focus();
                return;
            }
            #endregion

            try
            {
                var obj = new CustomerInfo();
                obj.Username = txtUsername.Text;
                obj.Password = passEncode;
                obj.CreditCard = txtCard.Text;
                obj.FullName = txtName.Text;
                obj.Bod = txtBirth.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;
                obj.Email = txtEmail.Text;
                obj.Avata = txtAvata.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                CustomerService.Customer_Insert(obj);
                Response.Redirect("Login.aspx");
                txtUsername.Text = txtCard.Text = txtName.Text = txtAddress.Text = txtPhone.Text = txtEmail.Text = "";
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}