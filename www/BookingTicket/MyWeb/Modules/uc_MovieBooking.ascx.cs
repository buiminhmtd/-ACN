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
    public partial class uc_MovieBooking : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoaFeedback();
                try
                {
                    string id = Request.QueryString["idS"].ToString();
                    var dt = new DataTable();
                    dt = ShowTimesService.ShowTimes_GetById(id);
                    lblDetail.Text = dt.Rows[0]["Detail"].ToString();

                    var dtC = new DataTable();
                    dtC = CustomerService.Customer_GetByTop("", "Username='" + Session["User"].ToString() + " '", "");
                    imgImage.ImageUrl = dtC.Rows[0]["Avata"].ToString();
                }
                catch (Exception ex)
                {
                    WebMsgBox.Show(ex.Message);
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["idS"].ToString();
                var dt = new DataTable();
                dt = ShowTimesService.ShowTimes_GetById(id);

                var dtC = new DataTable();
                dtC = CustomerService.Customer_GetByTop("", "Username='" + Session["User"].ToString() + " '", "");

                var obj = new FeedbackInfo();
                obj.FilId = dt.Rows[0]["FilId"].ToString();
                obj.FullName = dtC.Rows[0]["FullName"].ToString();
                obj.Avata = dtC.Rows[0]["Avata"].ToString();
                obj.Comment = txtConten.Text;
                FeedbackService.Feedback_Insert(obj);
                LoaFeedback();
                txtConten.Text = "";
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }

        private void LoaFeedback()
        {
            try
            {
                string id = Request.QueryString["idS"].ToString();
                var dt = new DataTable();
                dt = ShowTimesService.ShowTimes_GetById(id);

                RptComment.DataSource = FeedbackService.Feedback_GetByTop("", "FilId='" + dt.Rows[0]["FilId"].ToString() + "'" , "");
                RptComment.DataBind();
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
        }
    }
}