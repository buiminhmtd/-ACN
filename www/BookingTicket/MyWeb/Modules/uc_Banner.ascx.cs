using System;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules
{
    public partial class uc_Banner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovie();
                LoadSlide();
            }
        }

        private void LoadSlide()
        {
            try
            {
                RepeaterSlide.DataSource = SlideService.Slide_GetByTop("", "Slide.Status=1", "");
                RepeaterSlide.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        private void LoadMovie()
        {
            try
            {
                rptMovie.DataSource = ShowTimesService.ShowTimes_GetByTop1("5", "ShowTimes.Status=1", "NEWID()");
                rptMovie.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}