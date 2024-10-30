using System;
using System.Data;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Admin.Modules
{
    public partial class uc_Film : System.Web.UI.UserControl
    {
        static bool _insert = true;
        public static string ListFilm = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                LoadFilterTypeFilmDropDownList();
                LoadFilterCountryDropDownList();
                LoadFilterNewsNameAutocomplete();
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                ViewTypeFilm();
                ViewCountry();
                BindGrid();

            }
        }

        private void ViewCountry()
        {
            ddlCouId_Update.Items.Clear();
            ddlCouId_Update.Items.Add(new ListItem("=== Choose Country ===", "0"));
            var dt = new DataTable();
            dt = CountryService.Country_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlCouId_Update.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameCo"].ToString(), ""), dt.Rows[i]["CouId"].ToString()));
            }
            ddlCouId_Update.DataBind();
            dt.Rows.Clear();
        }

        private void ViewTypeFilm()
        {
            ddlTypId_Update.Items.Clear();
            ddlTypId_Update.Items.Add(new ListItem("=== Choose TypeFilm ===", "0"));
            var dt = new DataTable();
            dt = TypeFilmService.TypeFilm_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlTypId_Update.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameT"].ToString(), ""), dt.Rows[i]["TypId"].ToString()));
            }
            ddlTypId_Update.DataBind();
            dt.Rows.Clear();
        }

        private void LoadFilterCountryDropDownList()
        {
            ddlFilterCountry.Items.Clear();
            ddlFilterCountry.Items.Add(new ListItem(" -- View all -- ", ""));
            var dt = new DataTable();
            dt = CountryService.Country_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlFilterCountry.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameCo"].ToString(), "0"), dt.Rows[i]["CouId"].ToString()));
            }
            ddlFilterCountry.DataBind();
        }

        private void LoadFilterTypeFilmDropDownList()
        {
            ddlFilterypeFilm.Items.Clear();
            ddlFilterypeFilm.Items.Add(new ListItem(" -- View all -- ", ""));
            var dt = new DataTable();
            dt = TypeFilmService.TypeFilm_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlFilterypeFilm.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameT"].ToString(), "0"), dt.Rows[i]["TypId"].ToString()));
            }
            ddlFilterypeFilm.DataBind();
        }

        private void LoadFilterNewsNameAutocomplete()
        {
            try
            {
                string strName = "";
                var dt = new DataTable();
                dt = FilmService.Film_GetByAll();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strName += dt.Rows[i]["NameF"].ToString() + "|";
                }
                ListFilm = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|")
                               ? strName.Substring(0, strName.Length - 1)
                               : strName;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        private void BindGrid()
        {
            try
            {
                grdFilm.DataSource = FilmService.Film_GetByAll();
                grdFilm.DataBind();
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
                if (Common.StringClass.Check(ddlFilterypeFilm.SelectedValue))
                {
                    strWhere += " and TypId = '" + ddlFilterypeFilm.SelectedValue + "' ";
                }
                if (Common.StringClass.Check(ddlFilterCountry.SelectedValue))
                {
                    strWhere += " and CouId = '" + ddlFilterCountry.SelectedValue + "' ";
                }
                if (Common.StringClass.Check(txtFilterName.Text))
                {
                    strWhere += " and NameF like N'%" + txtFilterName.Text + "%' ";
                }
                if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                {
                    strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                }
                grdFilm.CurrentPageIndex = 0;
                grdFilm.DataSource = FilmService.Film_GetByTop("", strWhere, "");
                grdFilm.DataBind();
                if (grdFilm.PageCount <= 1)
                {
                    grdFilm.PagerStyle.Visible = false;
                }
                else
                {
                    grdFilm.PagerStyle.Visible = true;
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
            LoadFilterCountryDropDownList();
            LoadFilterNewsNameAutocomplete();
            LoadFilterTypeFilmDropDownList();
            ViewTypeFilm();
            ViewCountry();
            Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            BindGrid();
        }

        protected void lbtAddT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            ViewCountry();
            ViewTypeFilm();
            _insert = true;
        }

        protected void lbtAddB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            ViewCountry();
            ViewTypeFilm();
            _insert = true;
        }

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdFilm.Items.Count; i++)
                {
                    item = grdFilm.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            FilmService.Film_Delete(strId);
                        }
                    }
                }

                grdFilm.CurrentPageIndex = 0;
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
                for (int i = 0; i < grdFilm.Items.Count; i++)
                {
                    item = grdFilm.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            FilmService.Film_Delete(strId);
                        }
                    }
                }

                grdFilm.CurrentPageIndex = 0;
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

        protected void grdFilm_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdFilm.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdFilm_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdFilm.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdFilm_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string strCa = e.CommandArgument.ToString();
                string strWhere = " 1=1 ";
                if (e.CommandName == "Edit")
                {
                    _insert = false;
                    DataTable dt = FilmService.Film_GetById(strCa);
                    ddlCouId_Update.SelectedValue = dt.Rows[0]["CouId"].ToString();
                    ddlTypId_Update.SelectedValue = dt.Rows[0]["TypId"].ToString();
                    txtId.Value = dt.Rows[0]["FilId"].ToString();
                    txtName.Text = dt.Rows[0]["NameF"].ToString();
                    txtDirector.Text = dt.Rows[0]["Director"].ToString();
                    txtActor.Text = dt.Rows[0]["Actor"].ToString();
                    txtDuration.Text = dt.Rows[0]["Duration"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Picture"].ToString();
                    imgImageBig.ImageUrl = dt.Rows[0]["PictureBig"].ToString();
                    txtPicture.Text = dt.Rows[0]["Picture"].ToString();
                    txtPictureBig.Text = dt.Rows[0]["PictureBig"].ToString();
                    FCKeditorDescription.Value = dt.Rows[0]["Description"].ToString();
                    FCKeditorDetail.Value = dt.Rows[0]["Detail"].ToString();
                    chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    FilmService.Film_Delete(strCa);
                    BindGrid();
                }
                if (e.CommandName == "Status")
                {
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    FilmService.Film_Update_Status(strCa, strA);
                    BindGrid();
                }
                if (e.CommandName == "ascFilm")
                {
                    if (Common.StringClass.Check(ddlFilterypeFilm.SelectedValue))
                    {
                        strWhere += " and TypId = '" + ddlFilterypeFilm.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(ddlFilterCountry.SelectedValue))
                    {
                        strWhere += " and CouId = '" + ddlFilterCountry.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and NameF like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdFilm.DataSource = FilmService.Film_GetByTop("", strWhere, "NameF");
                    grdFilm.DataBind();
                    if (grdFilm.PageCount <= 1)
                    {
                        grdFilm.PagerStyle.Visible = false;
                    }
                }
                if (e.CommandName == "descFilm")
                {
                    if (Common.StringClass.Check(ddlFilterypeFilm.SelectedValue))
                    {
                        strWhere += " and TypId = '" + ddlFilterypeFilm.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(ddlFilterCountry.SelectedValue))
                    {
                        strWhere += " and CouId = '" + ddlFilterCountry.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and NameF like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Status = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    grdFilm.DataSource = FilmService.Film_GetByTop("", strWhere, "NameF desc");
                    grdFilm.DataBind();
                    if (grdFilm.PageCount <= 1)
                    {
                        grdFilm.PagerStyle.Visible = false;
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
            if (txtDirector.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Director not null !");
                txtDirector.Focus();
                return;
            }
            if (txtActor.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Actor not null !");
                txtActor.Focus();
                return;
            }
            if (txtDuration.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Duration not null !");
                txtDuration.Focus();
                return;
            }
            if (txtPicture.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Picture not null !");
                txtPicture.Focus();
                return;
            }
            #endregion

            try
            {
                var obj = new FilmInfo();
                obj.FilId = txtId.Value;
                obj.TypId = ddlTypId_Update.SelectedValue;
                obj.CouId = ddlCouId_Update.SelectedValue;
                obj.NameF = txtName.Text;
                obj.Director = txtDirector.Text;
                obj.Actor = txtActor.Text;
                obj.Duration = txtDuration.Text;
                obj.Description = FCKeditorDescription.Value;
                obj.Detail = FCKeditorDetail.Value;
                obj.Picture = txtPicture.Text;
                obj.PictureBig = txtPictureBig.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    FilmService.Film_Insert(obj);
                }
                else
                {
                    FilmService.Film_Update(obj);
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
            if (txtName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Name not null !");
                txtName.Focus();
                return;
            }
            if (txtDirector.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Director not null !");
                txtDirector.Focus();
                return;
            }
            if (txtActor.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Actor not null !");
                txtActor.Focus();
                return;
            }
            if (txtDuration.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Duration not null !");
                txtDuration.Focus();
                return;
            }
            if (txtPicture.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Picture not null !");
                txtPicture.Focus();
                return;
            }
            #endregion

            try
            {
                FilmInfo obj = new FilmInfo();
                obj.FilId = txtId.Value;
                obj.TypId = ddlTypId_Update.SelectedValue;
                obj.CouId = ddlCouId_Update.SelectedValue;
                obj.NameF = txtName.Text;
                obj.Director = txtDirector.Text;
                obj.Actor = txtActor.Text;
                obj.Duration = txtDuration.Text;
                obj.Description = FCKeditorDescription.Value;
                obj.Detail = FCKeditorDetail.Value;
                obj.Picture = txtPicture.Text;
                obj.PictureBig = txtPictureBig.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    FilmService.Film_Insert(obj);
                }
                else
                {
                    FilmService.Film_Update(obj);
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