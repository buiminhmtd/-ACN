using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class uc_Information : System.Web.UI.UserControl
    {
        Regex reg = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Information();
            }
        }

        private void Information()
        {
            try
            {
                DataTable dt = CustomerService.Customer_GetByTop("", "Username='" + Session["User"] + "'", "");
                txtId.Value = dt.Rows[0]["CusId"].ToString();
                txtUsername.Text = Session["User"].ToString();
                txtCard.Text = dt.Rows[0]["CreditCard"].ToString();
                txtName.Text = dt.Rows[0]["FullName"].ToString();
                txtBirth.Text = dt.Rows[0]["Bod"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtAvata.Text = dt.Rows[0]["Avata"].ToString();
                imgImage.ImageUrl = dt.Rows[0]["Avata"].ToString();
                chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string passEncode = StringClass.Encrypt(txtPassword.Text);
            #region[TestInput]
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
                obj.CusId = txtId.Value;
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
                CustomerService.Customer_Update(obj);
                WebMsgBox.Show("Change information success");
                Information();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}