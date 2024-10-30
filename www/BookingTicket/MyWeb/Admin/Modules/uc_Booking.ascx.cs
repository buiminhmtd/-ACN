using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admin.Modules
{
    public partial class uc_Booking : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Do you want to delete?');");
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                grdBooking.DataSource = BookingService.Booking_GetByAll();
                grdBooking.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void grdBooking_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string strCa = e.CommandArgument.ToString();
                txtId.Text = e.CommandArgument.ToString();
                if (e.CommandName == "Edit")
                {
                    grdCustomer.DataSource = BookingService.Booking_GetById(strCa);
                    grdCustomer.DataBind();

                    grdShopcard.DataSource = BookingService.Booking_GetById(strCa);
                    grdShopcard.DataBind();

                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                }
                if (e.CommandName == "Delete")
                {
                    BookingService.Booking_Delete(strCa);
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtUpdateT_Click(object sender, EventArgs e)
        {
            try
            {
                BookingService.Booking_Update_Status(txtId.Text);
                BindGrid();
                pnUpdate.Visible = false;
                pnView.Visible = true;
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
                BookingService.Booking_Update_Status(txtId.Text);
                BindGrid();
                pnUpdate.Visible = false;
                pnView.Visible = true;
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void lbtBackB_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnView.Visible = true;
        }

        protected void lbtBackT_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnView.Visible = true;
        }

        protected void grdBooking_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdBooking.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdBooking_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdBooking.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
                for (int i = 0; i < grdBooking.Items.Count; i++)
                {
                    item = grdBooking.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            BookingService.Booking_Delete(strId);
                        }
                    }
                }

                grdBooking.CurrentPageIndex = 0;
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
                for (int i = 0; i < grdBooking.Items.Count; i++)
                {
                    item = grdBooking.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            var dt = new DataTable();
                            BookingService.Booking_Delete(strId);
                        }
                    }
                }

                grdBooking.CurrentPageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}