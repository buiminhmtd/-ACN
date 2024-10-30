using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules
{
    public partial class uc_Movie : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFilm();
            }
        }

        private void LoadFilm()
        {
            try
            {
                rptMovie.DataSource = ShowTimesService.ShowTimes_GetByTop1("", "ShowTimes.Status=1", "");
                rptMovie.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}