using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Modules
{
    public partial class uc_BookingSuccess : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string id = Request.QueryString["idB"].ToString();
                    grdCustomer.DataSource = BookingService.Booking_GetById(id);
                    grdCustomer.DataBind();

                    grdShopcard.DataSource = BookingService.Booking_GetById(id);
                    grdShopcard.DataBind(); 
                }
                catch (Exception ex)
                {
                    WebMsgBox.Show(ex.Message);
                }
            }
        }
    }
}