using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using MyWeb.Common;
using MyWeb.Business;
using MyWeb.Data;

namespace MyWeb.Admin.Modules
{
    public partial class uc_Customer : System.Web.UI.UserControl
    {
        static bool _insert = true;
        public static string ListUsername = "";
        
        Regex reg = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsername.ReadOnly = false;
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                LoadFilterNewsNameAutocomplete();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                grdCustomer.DataSource = CustomerService.Customer_GetByAll();
                grdCustomer.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        private void LoadFilterNewsNameAutocomplete()
        {
            try
            {
                string strName = "";
                var dt = new DataTable();
                dt = CustomerService.Customer_GetByAll();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strName += dt.Rows[i]["FullName"].ToString() + "|";
                }
                ListUsername = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|")
                               ? strName.Substring(0, strName.Length - 1)
                               : strName;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            try
            {
                string strWhere = " 1=1 ";
                if (Common.StringClass.Check(txtFilterName.Text))
                {
                    strWhere += " and FullName like N'%" + txtFilterName.Text + "%' ";
                }
                if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                {
                    strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                }
                grdCustomer.CurrentPageIndex = 0;
                grdCustomer.DataSource = CustomerService.Customer_GetByTop("", strWhere, "");
                grdCustomer.DataBind();
                if (grdCustomer.PageCount <= 1)
                {
                    grdCustomer.PagerStyle.Visible = false;
                }
                else
                {
                    grdCustomer.PagerStyle.Visible = true;
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void UnFilter_Click(object sender, EventArgs e)
        {
            ControlClass.ResetControlValues(pnView);
            LoadFilterNewsNameAutocomplete();
            Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            BindGrid();
        }

        protected void grdCustomer_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string strCa = e.CommandArgument.ToString();
                string strWhere = " 1=1 ";
                if (e.CommandName == "Edit")
                {
                    _insert = false;
                    txtUsername.ReadOnly = true;
                    DataTable dt = CustomerService.Customer_GetById(strCa);
                    txtId.Value = dt.Rows[0]["CusId"].ToString();
                    txtUsername.Text = dt.Rows[0]["Username"].ToString();
                    txtCreditCard.Text = dt.Rows[0]["CreditCard"].ToString();
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtBod.Text = DateTimeClass.ConvertDateTime(dt.Rows[0]["Bod"].ToString(),"MM/dd/yyyy");
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtAvata.Text = dt.Rows[0]["Avata"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Avata"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    CustomerService.Customer_Delete(strCa);
                    BindGrid();
                }
                if (e.CommandName == "Status")
                {
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    CustomerService.Customer_Update_Status(strCa, strA);
                    BindGrid();
                }
                if (e.CommandName == "ascUsername")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and FullName like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdCustomer.DataSource = CustomerService.Customer_GetByTop("", strWhere, "Username");
                    grdCustomer.DataBind();
                    if (grdCustomer.PageCount <= 1)
                    {
                        grdCustomer.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "descUsername")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and FullName like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdCustomer.DataSource = CustomerService.Customer_GetByTop("", strWhere, "Username desc");
                    grdCustomer.DataBind();
                    if (grdCustomer.PageCount <= 1)
                    {
                        grdCustomer.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "ascFullName")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and FullName like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdCustomer.DataSource = CustomerService.Customer_GetByTop("", strWhere, "FullName");
                    grdCustomer.DataBind();
                    if (grdCustomer.PageCount <= 1)
                    {
                        grdCustomer.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "descFullName")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and FullName like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdCustomer.DataSource = CustomerService.Customer_GetByTop("", strWhere, "FullName desc");
                    grdCustomer.DataBind();
                    if (grdCustomer.PageCount <= 1)
                    {
                        grdCustomer.PagerStyle.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtAddT_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            _insert = true;
        }

        protected void lbtAddB_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            _insert = true;
        }

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdCustomer.Items.Count; i++)
                {
                    item = grdCustomer.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            CustomerService.Customer_Delete(strId);
                        }
                    }
                }

                grdCustomer.CurrentPageIndex = 0;
                LoadFilterNewsNameAutocomplete();
                BindGrid();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdCustomer.Items.Count; i++)
                {
                    item = grdCustomer.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            CustomerService.Customer_Delete(strId);
                        }
                    }
                }

                grdCustomer.CurrentPageIndex = 0;
                LoadFilterNewsNameAutocomplete();
                BindGrid();
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

        protected void lbtBackT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnView.Visible = true;
            _insert = false;
        }

        protected void lbtBackB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnView.Visible = true;
            _insert = false;
        }

        protected void grdCustomer_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCustomer.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void lbtUpdateT_Click(object sender, EventArgs e)
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
            if (txtCreditCard.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Credit Card not null !");
                txtCreditCard.Focus();
                return;
            }
            if (txtFullName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Full Name not null !");
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
                obj.CreditCard = txtCreditCard.Text;
                obj.FullName = txtFullName.Text;
                obj.Bod = txtBod.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;
                obj.Email = txtEmail.Text;
                obj.Avata = txtAvata.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    CustomerService.Customer_Insert(obj);
                }
                else
                {
                    CustomerService.Customer_Update(obj);
                }
                BindGrid();
                LoadFilterNewsNameAutocomplete();
                txtUsername.ReadOnly = true;
                pnView.Visible = true;
                pnUpdate.Visible = false;
                _insert = false;
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
            if (txtPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Password not null !");
                txtUsername.Focus();
                return;
            }
            if (txtCreditCard.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Credit Card not null !");
                txtCreditCard.Focus();
                return;
            }
            if (txtFullName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Full Name not null !");
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
            string passEncode = StringClass.Encrypt(txtPassword.Text);
            try
            {
                var obj = new CustomerInfo();
                obj.CusId = txtId.Value;
                obj.Username = txtUsername.Text;
                obj.Password = passEncode;
                obj.CreditCard = txtCreditCard.Text;
                obj.FullName = txtFullName.Text;
                obj.Bod = txtBod.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;
                obj.Email = txtEmail.Text;
                obj.Avata = txtAvata.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    CustomerService.Customer_Insert(obj);
                }
                else
                {
                    CustomerService.Customer_Update(obj);
                }
                BindGrid();
                LoadFilterNewsNameAutocomplete();
                txtUsername.ReadOnly = true;
                pnView.Visible = true;
                pnUpdate.Visible = false;
                _insert = false;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void grdCustomer_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grdCustomer.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut",
                                              "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() +
                                              ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick",
                                                             "Javascript:chkSelect_OnClick(this," +
                                                             e.Item.ItemIndex.ToString() + ")");
                    }
                }
            }
        }
    }
}