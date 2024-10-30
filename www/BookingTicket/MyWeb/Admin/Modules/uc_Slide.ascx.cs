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
    public partial class uc_Slide : System.Web.UI.UserControl
    {
        static bool _insert = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                ViewFilm();
                BindGrid();
            }
        }

        private void ViewFilm()
        {
            ddlFilId_Update.Items.Clear();
            ddlFilId_Update.Items.Add(new ListItem("=== Choose Film ===", "0"));
            var dt = new DataTable();
            dt = FilmService.Film_GetByAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlFilId_Update.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameF"].ToString(), ""), dt.Rows[i]["FilId"].ToString()));
            }
            ddlFilId_Update.DataBind();
            dt.Rows.Clear();
        }

        private void BindGrid()
        {
            try
            {
                grdSlide.DataSource = SlideService.Slide_GetByAll();
                grdSlide.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtAddT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            ViewFilm();
            _insert = true;
        }

        protected void lbtAddB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            ViewFilm();
            _insert = true;
        }

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridItem item = default(DataGridItem);
                for (int i = 0; i < grdSlide.Items.Count; i++)
                {
                    item = grdSlide.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            SlideService.Slide_Delete(strId);
                        }
                    }
                }

                grdSlide.CurrentPageIndex = 0;
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
                for (int i = 0; i < grdSlide.Items.Count; i++)
                {
                    item = grdSlide.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            SlideService.Slide_Delete(strId);
                        }
                    }
                }

                grdSlide.CurrentPageIndex = 0;
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

        protected void grdSlide_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdSlide.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdSlide_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdSlide.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdSlide_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string strCa = e.CommandArgument.ToString();
                string strWhere = " 1=1 ";
                if (e.CommandName == "Edit")
                {
                    _insert = false;
                    DataTable dt = SlideService.Slide_GetById(strCa);
                    txtId.Value = dt.Rows[0]["SliId"].ToString();
                    ddlFilId_Update.SelectedValue = dt.Rows[0]["FilId"].ToString();
                    txtImage.Text = dt.Rows[0]["Image"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Image"].ToString();
                    chkActive.Checked = dt.Rows[0]["Status"].ToString() == "1" || dt.Rows[0]["Status"].ToString() == "True";
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    SlideService.Slide_Delete(strCa);
                    BindGrid();
                }
                if (e.CommandName == "Status")
                {
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SlideService.Silde_Update_Status(strCa, strA);
                    BindGrid();
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
            try
            {
                SlideInfo obj = new SlideInfo();
                obj.SliId = txtId.Value;
                obj.FilId = ddlFilId_Update.SelectedValue;
                obj.Image = txtImage.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    SlideService.Slide_Insert(obj);
                }
                else
                {
                    SlideService.Slide_Update(obj);
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
            try
            {
                SlideInfo obj = new SlideInfo();
                obj.SliId = txtId.Value;
                obj.FilId = ddlFilId_Update.SelectedValue;
                obj.Image = txtImage.Text;
                obj.Status = chkActive.Checked ? "1" : "0";
                if (_insert == true)
                {
                    SlideService.Slide_Insert(obj);
                }
                else
                {
                    SlideService.Slide_Update(obj);
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