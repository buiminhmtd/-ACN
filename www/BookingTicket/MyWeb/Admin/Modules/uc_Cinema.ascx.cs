using System;
using System.Data;
using System.Web.UI.WebControls;
using MyWeb.Common;
using MyWeb.Business;
using MyWeb.Data;

namespace MyWeb.Admin.Modules
{
    public partial class uc_Cinema : System.Web.UI.UserControl
    {
        static bool _insert = true;
        public static string ListCinema = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                grdCinema.DataSource = CinemaService.Cinema_GetByAll();
                grdCinema.DataBind();
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
                dt = CinemaService.Cinema_GetByAll();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strName += dt.Rows[i]["NameCi"].ToString() + "|";
                }
                ListCinema = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|")
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
                    strWhere += " and NameCi like N'%" + txtFilterName.Text + "%' ";
                }
                if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                {
                    strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                }
                grdCinema.CurrentPageIndex = 0;
                grdCinema.DataSource = CinemaService.Cinema_GetByTop("", strWhere, "");
                grdCinema.DataBind();
                if (grdCinema.PageCount <= 1)
                {
                    grdCinema.PagerStyle.Visible = false;
                }
                else
                {
                    grdCinema.PagerStyle.Visible = true;
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

        protected void lbtAddT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            _insert = true;
        }

        protected void lbtAddB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            _insert = true;
        }

        protected void lbtRefreshT_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void lbtRefreshB_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdCinema_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdCinema.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdCinema.Items.Count; i++)
                {
                    item = grdCinema.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            CinemaService.Cinema_Delete(strId);
                        }
                    }
                }

                grdCinema.CurrentPageIndex = 0;
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
                for (int i = 0; i < grdCinema.Items.Count; i++)
                {
                    item = grdCinema.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            CinemaService.Cinema_Delete(strId);
                        }
                    }
                }

                grdCinema.CurrentPageIndex = 0;
                LoadFilterNewsNameAutocomplete();
                BindGrid();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void grdCinema_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCinema.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdCinema_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                
                string strCa = e.CommandArgument.ToString();
                string strWhere = " 1=1 ";
                if (e.CommandName == "Edit")
                {
                    _insert = false;
                    DataTable dt = CinemaService.Cinema_GetById(strCa);
                    txtId.Value = dt.Rows[0]["CinId"].ToString();
                    txtName.Text = dt.Rows[0]["NameCi"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtSeats.Text = dt.Rows[0]["Seats"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txImage.Text = dt.Rows[0]["Image"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Image"].ToString();
                    chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    CinemaService.Cinema_Delete(strCa);
                    BindGrid();
                }
                if (e.CommandName == "Status")
                {
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    CinemaService.Cinema_Update_Status(strCa, strA);
                    BindGrid();
                }
                if (e.CommandName == "ascCinema")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and NameCi like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdCinema.DataSource = CinemaService.Cinema_GetByTop("", strWhere, "NameCi");
                    grdCinema.DataBind();
                    if (grdCinema.PageCount <= 1)
                    {
                        grdCinema.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "descCinema")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and NameCi like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdCinema.DataSource = CinemaService.Cinema_GetByTop("", strWhere, "NameCi desc");
                    grdCinema.DataBind();
                    if (grdCinema.PageCount <= 1)
                    {
                        grdCinema.PagerStyle.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
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

        protected void lbtUpdateT_Click(object sender, EventArgs e)
        {
            #region[TestInput]
            if (txtName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Name not null !");
                txtName.Focus();
                return;
            }
            if (txtAddress.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Address not null !");
                txtAddress.Focus();
                return;
            }
            if (txtSeats.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Seats not null !");
                txtSeats.Focus();
                return;
            }
            if (txtPhone.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Phone not null !");
                txtPhone.Focus();
                return;
            }
            #endregion

            try
            {
                var obj = new CinemaInfo();
                obj.CinId = txtId.Value;
                obj.NameCi = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.Seats = txtSeats.Text;
                obj.Phone = txtPhone.Text;
                obj.Image = txImage.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    CinemaService.Cinema_Insert(obj);
                }
                else
                {
                    CinemaService.Cinema_Update(obj);
                }
                BindGrid();
                LoadFilterNewsNameAutocomplete();
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
            if (txtName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Name not null !");
                txtName.Focus();
                return;
            }
            if (txtAddress.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Address not null !");
                txtAddress.Focus();
                return;
            }
            if (txtSeats.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Seats not null !");
                txtSeats.Focus();
                return;
            }
            if (txtPhone.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Phone not null !");
                txtPhone.Focus();
                return;
            }
            #endregion

            try
            {
                var obj = new CinemaInfo();
                obj.CinId = txtId.Value;
                obj.NameCi = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.Seats = txtSeats.Text;
                obj.Phone = txtPhone.Text;
                obj.Image = txImage.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    CinemaService.Cinema_Insert(obj);
                }
                else
                {
                    CinemaService.Cinema_Update(obj);
                }
                BindGrid();
                LoadFilterNewsNameAutocomplete();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                _insert = false;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}