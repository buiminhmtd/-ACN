using System;
using System.Data;
using System.Text.RegularExpressions;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Admin.Modules
{
    public partial class uc_MyInformation : System.Web.UI.UserControl
    {
        Regex reg = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                grdAdmin.DataSource = AdminService.Admin_GetByAll();
                grdAdmin.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtRefreshT_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void lbtRefreshB_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdAdmin_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strCa = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                DataTable dt = AdminService.Admin_GetById(strCa);
                txtId.Value = dt.Rows[0]["AdmId"].ToString();
                txtUsername.Text = dt.Rows[0]["Username"].ToString();
                txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                txtBod.Text = DateTimeClass.ConvertDateTime(dt.Rows[0]["Bod"].ToString(),"MM/dd/yyyy");
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                pnUpdate.Visible = true;
                pnView.Visible = false;
            } 
        }

        protected void lbtBackT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnView.Visible = true;
        }

        protected void lbtBackB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnView.Visible = true;
        }

        protected void lbtUpdateT_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            if (txtUsername.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Username not null !");
                txtUsername.Focus();
                return;
            }
            if (txtFullName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("FullName not null !");
                txtFullName.Focus();
                return;
            }
            if (txtBod.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birth not null !");
                txtBod.Focus();
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
                WebMsgBox.Show("Email not null !");
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
                var obj = new AdminInfo();
                obj.AdmId = txtId.Value;
                obj.Username = txtUsername.Text;
                obj.FullName = txtFullName.Text;
                obj.Bod = txtBod.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;
                obj.Email = txtEmail.Text;
                AdminService.Admin_Update(obj);
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtUpdateB_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            if (txtUsername.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Username not null !");
                txtUsername.Focus();
                return;
            }
            if (txtFullName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("FullName not null !");
                txtFullName.Focus();
                return;
            }
            if (txtBod.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birth not null !");
                txtBod.Focus();
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
                WebMsgBox.Show("Email not null !");
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
                var obj = new AdminInfo();
                obj.AdmId = txtId.Value;
                obj.Username = txtUsername.Text;
                obj.FullName = txtFullName.Text;
                obj.Bod = txtBod.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;
                obj.Email = txtEmail.Text;
                AdminService.Admin_Update(obj);
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}