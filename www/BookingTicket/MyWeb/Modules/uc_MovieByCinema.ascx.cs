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

namespace MyWeb.Modules
{
    public partial class uc_MovieByCinema : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInf();
            }
        }

        private void LoadInf()
        {
            try
            {
                if (Session["IDF"] != null)
                {
                    rptShowTime.DataSource = ShowTimesService.ShowTimes_GetByFilId(Session["IDF"].ToString());
                    rptShowTime.DataBind();

                    var dt = new DataTable();
                    dt = ShowTimesService.ShowTimes_GetByFilId(Session["IDF"].ToString());
                    Session["IDShow"] = dt.Rows[0]["ShoId"].ToString();

                    rptMovie.DataSource = ShowTimesService.ShowTimes_GetByTop1("", "ShowTimes.Status=1 and ShoId<>'" + Session["IDShow"].ToString() + "'", "");
                    rptMovie.DataBind();
                }
                
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        protected void rptShowTime_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string strCa = e.CommandArgument.ToString();
                if (e.CommandName == "tickets")
                {
                    Response.Redirect("/Booking.aspx?idS=" + strCa);
                }
            }
        }
    }
}