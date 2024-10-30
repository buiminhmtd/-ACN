using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Modules
{
    public partial class uc_Booking : System.Web.UI.UserControl
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
            string id = Request.QueryString["idS"].ToString();
            var dt1 = new DataTable();
            dt1 = BookingService.Booking_Sum(id);
            //int daco = Int32.Parse(dt1.Rows[0]["tickets"].ToString());
            var dt = new DataTable();
            dt = ShowTimesService.ShowTimes_GetById(id);
            lblNameCinema.Text = dt.Rows[0]["NameCi"].ToString();
            Imagethumb.ImageUrl = dt.Rows[0]["PictureBig"].ToString();
            lblAddress.Text = dt.Rows[0]["Address"].ToString();
            lblFilm.Text = dt.Rows[0]["NameF"].ToString();
            lblSeats.Text = dt.Rows[0]["Seats"].ToString() + " (total)";
            //int tong = Int32.Parse(dt.Rows[0]["Seats"].ToString());
            lblDuration.Text = dt.Rows[0]["Duration"].ToString() + " minutes";
            lblShowtime.Text = DateTimeClass.ConvertDateTime(dt.Rows[0]["ShowTime"].ToString(),"dd/MM/yyyy");
            lblTime.Text = DateTimeClass.ConvertTime(dt.Rows[0]["Time"].ToString());
            lblPrice.Text = StringClass.FormatNumber(dt.Rows[0]["Price"].ToString());
            double price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
            double number = Convert.ToDouble(txtNumber.Text);
            string str = (price * number).ToString();
            lblTotal.Text = StringClass.FormatNumber(str);
            //string str2 = (tong - daco).ToString();
            //lblNumbertickets.Text = str2 + " (empty)";
            lblNumbertickets.Text = dt1.Rows[0]["tickets"].ToString();
            if (dt1.Rows[0]["tickets"].ToString() == dt.Rows[0]["Seats"].ToString())
            {
                lblMessage.Text = "Not tickets";
                txtNumber.ReadOnly = true;
                lblOrder.Enabled = false;
            }
            //if (dt1.Rows[0]["tickets"].ToString() == "")
            //{
            //    lblNumbertickets.Text = "0";
            //}
            else
            {
                lblMessage.Text = "";
                txtNumber.ReadOnly = false;
                lblOrder.Enabled = true;
            }
        }

        protected void txtNumber_TextChanged(object sender, EventArgs e)
        {
            LoadInf();
        }

        protected void lblOrder_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["idS"].ToString();

            var dt1 = new DataTable();
            dt1 = ShowTimesService.ShowTimes_GetById(id);
            lblFilm.Text = dt1.Rows[0]["NameF"].ToString();
            double price = Convert.ToDouble(dt1.Rows[0]["Price"].ToString());
            double number = Convert.ToDouble(txtNumber.Text);
            string str = (price * number).ToString();
            lblTotal.Text = StringClass.FormatNumber(str);
            DataTable dt = CustomerService.Customer_GetByTop("", "Username='" + Session["User"] + "'", "");
            BookingInfo obj = new BookingInfo();
            obj.CusId = dt.Rows[0]["CusId"].ToString();
            obj.ShoId = id;
            obj.Bilmoney = str;
            obj.Quantity = txtNumber.Text;
            BookingService.Booking_Insert(obj);

            var dt2 = new DataTable();
            dt2 = BookingService.Booking_GetByTop("", "", "BooId DESC");

            string to = dt.Rows[0]["Email"].ToString();
            int port = 587;
            string subject = "Message Admin";
            string strContent = "You booking success movie : " + "\n" + dt1.Rows[0]["NameF"].ToString() + "\n" + 
                                "Cinema : " + dt1.Rows[0]["NameCi"].ToString() + "\n" + 
                                "Date movie: " + dt1.Rows[0]["ShowTime"].ToString() + "\n" + 
                                "Time movie: " + dt1.Rows[0]["Time"].ToString() + "\n" +
                                "Quantity ticket : " + dt2.Rows[0]["Quantity"].ToString() + "\n" +
                                "Total amount " + StringClass.FormatNumber(dt2.Rows[0]["Bilmoney"].ToString()) + "\n" +
                                "We will notify you when you pay this ticket. Thank you" + "\n" +
                                "Note : Please, do not reply to email";
            string content = strContent;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Port = port;
            client.Host = "smtp.gmail.com";
            client.Credentials = new NetworkCredential("tuanxh12a2@gmail.com", "Noicomdiento");// mail o day
            MailAddress from = new MailAddress("tuanxh12a2@gmail.com");
            MailAddress toAddress = new MailAddress(to);
            MailMessage message = new MailMessage(from, toAddress);
            message.Body = content;
            message.Subject = subject;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                WebMsgBox.Show(ex.Message);
            }
            Response.Redirect("BookingSuccess.aspx?idB=" + dt2.Rows[0]["BooId"].ToString());
        }
    }
}