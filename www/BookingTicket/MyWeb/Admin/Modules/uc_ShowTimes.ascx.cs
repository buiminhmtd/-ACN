using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Admin.Modules
{
    public partial class uc_ShowTimes : System.Web.UI.UserControl
    {
        static bool _insert = true;
        public static string ListFilm = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                LoadFilterCinemaDropDownList();
                LoadFilterFilmDropDownList();
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                ViewFilm();
                ViewCinema();
                BindGrid();
            }
        }

        private void ViewCinema()
        {
            ddlCinId_Update.Items.Clear();
            ddlCinId_Update.Items.Add(new ListItem("=== Choose Country ===", "0"));
            var dt = new DataTable();
            dt = CinemaService.Cinema_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlCinId_Update.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameCi"].ToString(), ""), dt.Rows[i]["CinId"].ToString()));
            }
            ddlCinId_Update.DataBind();
            dt.Rows.Clear();
        }

        private void ViewFilm()
        {
            ddlFilId_Update.Items.Clear();
            ddlFilId_Update.Items.Add(new ListItem("=== Choose Country ===", "0"));
            var dt = new DataTable();
            dt = FilmService.Film_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlFilId_Update.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameF"].ToString(), ""), dt.Rows[i]["FilId"].ToString()));
            }
            ddlFilId_Update.DataBind();
            dt.Rows.Clear();
        }

        //private void LoadFilterNewsNameAutocomplete()
        //{
        //    try
        //    {
        //        string strName = "";
        //        var dt = new DataTable();
        //        dt = FilmService.Film_GetByAll();
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            strName += dt.Rows[i]["NameF"].ToString() + "|";
        //        }
        //        ListFilm = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|")
        //                       ? strName.Substring(0, strName.Length - 1)
        //                       : strName;
        //    }
        //    catch (Exception ex)
        //    {
        //        WebMsgBox.Show(ex.Message);
        //    }
        //}

        private void LoadFilterCinemaDropDownList()
        {
            ddlFilterCinema.Items.Clear();
            ddlFilterCinema.Items.Add(new ListItem(" -- View all -- ", ""));
            var dt = new DataTable();
            dt = CinemaService.Cinema_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlFilterCinema.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameCi"].ToString(), "0"), dt.Rows[i]["CinId"].ToString()));
            }
            ddlFilterCinema.DataBind();
        }

        private void LoadFilterFilmDropDownList()
        {
            ddlFilterFilm.Items.Clear();
            ddlFilterFilm.Items.Add(new ListItem(" -- View all -- ", ""));
            var dt = new DataTable();
            dt = FilmService.Film_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlFilterFilm.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameF"].ToString(), "0"), dt.Rows[i]["FilId"].ToString()));
            }
            ddlFilterFilm.DataBind();
        }

        private void BindGrid()
        {
            try
            {
                grdShowTimes.DataSource = ShowTimesService.ShowTimes_GetByAll();
                grdShowTimes.DataBind();
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
                if (Common.StringClass.Check(ddlFilterCinema.SelectedValue))
                {
                    strWhere += " and CinId = '" + ddlFilterCinema.SelectedValue + "' ";
                }
                if (Common.StringClass.Check(ddlFilterFilm.SelectedValue))
                {
                    strWhere += " and FilId = '" + ddlFilterFilm.SelectedValue + "' ";
                }
                if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                {
                    strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                }
                grdShowTimes.CurrentPageIndex = 0;
                grdShowTimes.DataSource = ShowTimesService.ShowTimes_GetByTop("", strWhere, "");
                grdShowTimes.DataBind();
                if (grdShowTimes.PageCount <= 1)
                {
                    grdShowTimes.PagerStyle.Visible = false;
                }
                else
                {
                    grdShowTimes.PagerStyle.Visible = true;
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void UnFilter_Click(object sender, EventArgs e)
        {
            ControlClass.ResetControlValues(pnUpdate);
            LoadFilterCinemaDropDownList();
            LoadFilterFilmDropDownList();
            ViewCinema();
            ViewFilm();
            Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            BindGrid();
        }

        protected void lbtAddT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            ViewCinema();
            ViewFilm();
            _insert = true;
        }

        protected void lbtAddB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            ViewCinema();
            ViewFilm();
            _insert = true;
        }

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdShowTimes.Items.Count; i++)
                {
                    item = grdShowTimes.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            ShowTimesService.ShowTimes_Delete(strId);
                        }
                    }
                }

                grdShowTimes.CurrentPageIndex = 0;
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
                for (int i = 0; i < grdShowTimes.Items.Count; i++)
                {
                    item = grdShowTimes.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            ShowTimesService.ShowTimes_Delete(strId);
                        }
                    }
                }

                grdShowTimes.CurrentPageIndex = 0;
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

        protected void lbtUpdatepriceT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdShowTimes.Items.Count; i++)
                {
                    item = grdShowTimes.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        TextBox stxtGia = ((TextBox)item.FindControl("txtPrice"));
                        NumberClass.OnlyInputNumber(stxtGia);
                        string strId = item.Cells[1].Text;
                        ShowTimesService.ShowTimes_Update_Price(strId,stxtGia.Text);
                    }
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtUpdatepriceB_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdShowTimes.Items.Count; i++)
                {
                    item = grdShowTimes.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        TextBox stxtGia = ((TextBox)item.FindControl("txtPrice"));
                        NumberClass.OnlyInputNumber(stxtGia);
                        string strId = item.Cells[1].Text;
                        ShowTimesService.ShowTimes_Update_Price(strId, stxtGia.Text);
                    }
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void grdShowTimes_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdShowTimes.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdShowTimes_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdShowTimes.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdShowTimes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string strCa = e.CommandArgument.ToString();
                string strWhere = " 1=1 ";
                DataGridItem item = default(DataGridItem);
                if (e.CommandName == "Edit")
                {
                    _insert = false;
                    DataTable dt = ShowTimesService.ShowTimes_GetById(strCa);
                    ddlCinId_Update.SelectedValue = dt.Rows[0]["CinId"].ToString();
                    ddlFilId_Update.SelectedValue = dt.Rows[0]["FilId"].ToString();
                    txtId.Value = dt.Rows[0]["ShoId"].ToString();
                    txtShowTime.Text = dt.Rows[0]["ShowTime"].ToString();
                    txtPrice.Text = dt.Rows[0]["Price"].ToString();
                    txtTime.Text = dt.Rows[0]["Time"].ToString();
                    chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    ShowTimesService.ShowTimes_Delete(strCa);
                    BindGrid();
                }
                if (e.CommandName == "Status")
                {
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    ShowTimesService.ShowTimes_Update_Status(strCa, strA);
                    BindGrid();
                }
                if (e.CommandName == "ascPrice")
                {
                    if (Common.StringClass.Check(ddlFilterCinema.SelectedValue))
                    {
                        strWhere += " and CinId = '" + ddlFilterCinema.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(ddlFilterFilm.SelectedValue))
                    {
                        strWhere += " and FilId = '" + ddlFilterFilm.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdShowTimes.DataSource = ShowTimesService.ShowTimes_GetByTop("", strWhere, "Price");
                    grdShowTimes.DataBind();
                    if (grdShowTimes.PageCount <= 1)
                    {
                        grdShowTimes.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "sortdesc")
                {
                    if (Common.StringClass.Check(ddlFilterCinema.SelectedValue))
                    {
                        strWhere += " and CinId = '" + ddlFilterCinema.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(ddlFilterFilm.SelectedValue))
                    {
                        strWhere += " and FilId = '" + ddlFilterFilm.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdShowTimes.DataSource = ShowTimesService.ShowTimes_GetByTop("", strWhere, "NameF");
                    grdShowTimes.DataBind();
                    if (grdShowTimes.PageCount <= 1)
                    {
                        grdShowTimes.PagerStyle.Visible = false;
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
            if (txtShowTime.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("ShowTime not null !");
                txtShowTime.Focus();
                return;
            }
            if (txtPrice.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Price not null !");
                txtPrice.Focus();
                return;
            }
            if (txtTime.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Time not null !");
                txtPrice.Focus();
                return;
            }
            #endregion
            ShowTimesInfo obj = new ShowTimesInfo();
            obj.ShoId = txtId.Value;
            obj.FilId = ddlFilId_Update.SelectedValue;
            obj.CinId = ddlCinId_Update.SelectedValue;
            obj.ShowTime = txtShowTime.Text;
            obj.Time = txtTime.Text;
            obj.Price = txtPrice.Text;
            obj.Status = chkActive.Checked ? "1" : "0";
            try
            {
                if (_insert == true)
                {
                    ShowTimesService.ShowTimes_Insert(obj);
                }
                else
                {
                    ShowTimesService.ShowTimes_Update(obj);
                }
                BindGrid();
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
            if (txtShowTime.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("ShowTime not null !");
                txtShowTime.Focus();
                return;
            }
            if (txtPrice.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Price not null !");
                txtPrice.Focus();
                return;
            }
            #endregion
            ShowTimesInfo obj = new ShowTimesInfo();
            obj.ShoId = txtId.Value;
            obj.FilId = ddlFilId_Update.SelectedValue;
            obj.CinId = ddlCinId_Update.SelectedValue;
            obj.ShowTime = txtShowTime.Text;
            obj.Price = txtPrice.Text;
            obj.Time = txtTime.Text;
            obj.Status = chkActive.Checked ? "1" : "0";
            try
            {
                if (_insert == true)
                {
                    ShowTimesService.ShowTimes_Insert(obj);
                }
                else
                {
                    ShowTimesService.ShowTimes_Update(obj);
                }
                BindGrid();
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