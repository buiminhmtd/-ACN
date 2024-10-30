using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MyWeb.Business;
using System.Web.UI.WebControls;
using MyWeb.Common;

namespace MyWeb.Modules
{
    public partial class uc_Cinema : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCinema();
            }
        }

        private void LoadCinema()
        {
            try
            {
                rptCinema.DataSource = CinemaService.Cinema_GetByTop("", "Status=1","");
                rptCinema.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}