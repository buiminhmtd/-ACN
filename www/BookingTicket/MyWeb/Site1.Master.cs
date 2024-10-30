using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewCinema();
                LoadMovie();
            }
            if (Session["User"] != null)
            {
                lblLogin.Visible = false;
                lblSuccess.Visible = true;
                lblUsername.Text = "Hi! " + Session["User"].ToString();
            }
            else
            {
                lblLogin.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        //private void ViewCinema()
        //{
        //    ddlCinema.Items.Clear();
        //    ddlCinema.Items.Add(new ListItem("=== Choose Cinema ===", "0"));
        //    var dt = new DataTable();
        //    dt = CinemaService.Cinema_GetByAll();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ddlCinema.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["NameCi"].ToString(), ""), dt.Rows[i]["CinId"].ToString()));
        //    }
        //    ddlCinema.DataBind();
        //    dt.Rows.Clear();
        //}

        protected void lbtOut_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("Default.aspx");
        }

        private void LoadMovie()
        {
            try
            {
                rptMovie.DataSource = ShowTimesService.ShowTimes_GetByTop1("5", "ShowTimes.Status=1", "ShowTimes.[View] desc");
                rptMovie.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}