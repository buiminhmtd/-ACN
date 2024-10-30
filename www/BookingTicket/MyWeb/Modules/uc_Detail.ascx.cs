using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules
{
    public partial class uc_Detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFilmById();
            }
        }

        private void LoadFilmById()
        {
            try
            {
                string id = Request.QueryString["id"].ToString();
                ShowTimesService.ShowTimes_Update_View(id);
                var dt = new DataTable();
                dt = FilmService.Film_GetById(id);
                Session["IDF"] = dt.Rows[0]["FilId"].ToString();
                Imagethumb.ImageUrl = dt.Rows[0]["PictureBig"].ToString();
                lblName.Text = dt.Rows[0]["NameF"].ToString();
                lblDirector.Text = dt.Rows[0]["Director"].ToString();
                lblActor.Text = dt.Rows[0]["Actor"].ToString();
                lblDuration.Text = dt.Rows[0]["Duration"].ToString() + " minutes";
                ltDescription.Text = dt.Rows[0]["Description"].ToString();
                lblTypeFilm.Text = dt.Rows[0]["NameT"].ToString();
                lblCountry.Text = dt.Rows[0]["NameCo"].ToString();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}