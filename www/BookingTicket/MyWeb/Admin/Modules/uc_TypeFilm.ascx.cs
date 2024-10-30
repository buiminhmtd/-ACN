using System;
using System.Data;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Admin.Modules
{
    public partial class uc_TypeFilm : System.Web.UI.UserControl
    {
        static bool _insert = true;
        public static string ListTypeFilm = "";
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
                grdTypeFilm.DataSource = TypeFilmService.TypeFilm_GetByAll();
                grdTypeFilm.DataBind();
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
                dt = TypeFilmService.TypeFilm_GetByAll();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strName += dt.Rows[i]["NameT"].ToString() + "|";
                }
                ListTypeFilm = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|")
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
                    strWhere += " and NameT like N'%" + txtFilterName.Text + "%' ";
                }
                if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                {
                    strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                }
                grdTypeFilm.CurrentPageIndex = 0;
                grdTypeFilm.DataSource = TypeFilmService.TypeFilm_GetByTop("", strWhere, "");
                grdTypeFilm.DataBind();
                if (grdTypeFilm.PageCount <= 1)
                {
                    grdTypeFilm.PagerStyle.Visible = false;
                }
                else
                {
                    grdTypeFilm.PagerStyle.Visible = true;
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

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdTypeFilm.Items.Count; i++)
                {
                    item = grdTypeFilm.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            TypeFilmService.TypeFilm_Delete(strId);
                        }
                    }
                }

                grdTypeFilm.CurrentPageIndex = 0;
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
                for (int i = 0; i < grdTypeFilm.Items.Count; i++)
                {
                    item = grdTypeFilm.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            TypeFilmService.TypeFilm_Delete(strId);
                        }
                    }
                }

                grdTypeFilm.CurrentPageIndex = 0;
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

        protected void grdTypeFilm_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdTypeFilm.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdTypeFilm_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdTypeFilm.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdTypeFilm_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string strCa = e.CommandArgument.ToString();
                string strWhere = " 1=1 ";
                if (e.CommandName == "Edit")
                {
                    _insert = false;
                    DataTable dt = TypeFilmService.TypeFilm_GetById(strCa);
                    txtId.Value = dt.Rows[0]["TypId"].ToString();
                    txtName.Text = dt.Rows[0]["NameT"].ToString();
                    chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    TypeFilmService.TypeFilm_Delete(strCa);
                    BindGrid();
                }
                if (e.CommandName == "Status")
                {
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    TypeFilmService.TypeFilm_Update_Status(strCa, strA);
                    BindGrid();
                }
                if (e.CommandName == "ascTypeFilm")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and NameT like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdTypeFilm.DataSource = TypeFilmService.TypeFilm_GetByTop("", strWhere, "NameT");
                    grdTypeFilm.DataBind();
                    if (grdTypeFilm.PageCount <= 1)
                    {
                        grdTypeFilm.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "descTypeFilm")
                {
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and NameT like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdTypeFilm.DataSource = TypeFilmService.TypeFilm_GetByTop("", strWhere, "NameT desc");
                    grdTypeFilm.DataBind();
                    if (grdTypeFilm.PageCount <= 1)
                    {
                        grdTypeFilm.PagerStyle.Visible = false;
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
            #endregion

            try
            {
                var obj = new TypeFilmInfo();
                obj.TypId = txtId.Value;
                obj.NameT = txtName.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    TypeFilmService.TypeFilm_Insert(obj);
                }
                else
                {
                    TypeFilmService.TypeFilm_Update(obj);
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
            #endregion

            try
            {
                var obj = new TypeFilmInfo();
                obj.TypId = txtId.Value;
                obj.NameT = txtName.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    TypeFilmService.TypeFilm_Insert(obj);
                }
                else
                {
                    TypeFilmService.TypeFilm_Update(obj);
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