using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
//using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using System.Web.UI.WebControls;
using MovieBooking.Models;
using static System.Net.Mime.MediaTypeNames;
using PayPal.Api;
using System.Runtime.Remoting.Contexts;
using System.Globalization;

namespace MovieBooking.Controllers
{
    public class BookingsController : Controller
    {
        private BookingModel db = new BookingModel();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Showtime).Include(b => b.User);
            return View(bookings.ToList());
        }
        public ActionResult BookTicket(int? id)
        {

            System.Diagnostics.Debug.WriteLine("Giá trị của biến x: " + 1);
            // Kiểm tra nếu người dùng đã đăng nhập
            if (Session["userName"] != null)
            {
                // Lấy thông tin người dùng từ session và điền vào form
                ViewBag.movieid = id.ToString();
                ViewBag.UserName = Session["userName"];
                ViewBag.UserEmail = Session["userEmail"];
                ViewBag.UserPhone = Session["userPhone"];
                return View(db);
            }
            else
            {
                // Nếu người dùng chưa đăng nhập, có thể hiển thị thông báo hoặc chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "Users");
            }

        }

        [HttpGet]
        public JsonResult GetSeatStatus(int movie_id, String start_time, int screen_id)
        {
            System.Diagnostics.Debug.WriteLine(movie_id.ToString());
            System.Diagnostics.Debug.WriteLine(start_time);
            System.Diagnostics.Debug.WriteLine(screen_id);

            DateTime startTime = DateTime.Parse(start_time);
            System.Diagnostics.Debug.WriteLine(startTime);

            // Lấy suất chiếu
            var showtime = db.Showtimes
                .SingleOrDefault(st => st.movie_id == movie_id && 
                st.start_time == startTime && st.screen_id == screen_id);

            //System.Diagnostics.Debug.WriteLine(showtime.showtime_id + " - " + showtime.movie_id);

            try
            {
                // Lấy danh sách ghế đã đặt với thông tin đầy đủ từ Booking
                var bookedSeats = db.Booking_Details
                    .Where(bd => bd.Booking.showtime_id == showtime.showtime_id) // Include thông tin Booking
                    .Select(bd => new
                    {
                        seat_label = bd.Seat.seat_row + bd.Seat.seat_number,
                        isBooked = true
                    })
                    .ToList();

                foreach (var i in bookedSeats)
                    System.Diagnostics.Debug.WriteLine(i.seat_label + i.isBooked + i.ToString());

                System.Diagnostics.Debug.WriteLine("10000000000");
                return Json(bookedSeats, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { 
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return null;
            }

        }
        ///////
        [HttpGet]
        public JsonResult GetShowTimes(string date)
        {
            // Chuyển chuỗi ngày thành DateTime
            DateTime selectedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Lấy dữ liệu từ database (ví dụ)
            var showTimes = db.Showtimes
                .Where(st => st.start_time.HasValue &&
                            st.start_time.Value.Year == selectedDate.Year &&
                            st.start_time.Value.Month == selectedDate.Month &&
                            st.start_time.Value.Day == selectedDate.Day) // So sánh ngày
                .ToList()  // Lấy toàn bộ dữ liệu vào bộ nhớ
                .Select(st => new
                {
                    time = st.start_time.Value.ToString("HH:mm:ss") // Chuyển đổi giờ sau khi dữ liệu đã được tải vào bộ nhớ
                })
                .ToList();

            return Json(showTimes, JsonRequestBehavior.AllowGet);
        }
        ////////////////////////////////////
        [HttpPost]
        public ActionResult CreateBooking(int movieId, string date, string showTime, int screenId, List<string> selectedSeats, decimal totalPrice)
        {
            try
            {

                // Kiểm tra đăng nhập
                if (Session["userId"] == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Vui lòng đăng nhập để đặt vé"
                    });
                }

                // Lấy user ID từ session
                int userId = Convert.ToInt32(Session["userId"]);
                TimeSpan start_hour = TimeSpan.Parse(showTime);
                DateTime start_time = DateTime.Parse(date + " " + start_hour);
                Showtime st = db.Showtimes.Where(p => p.start_time == start_time && p.movie_id == movieId && p.screen_id == screenId).SingleOrDefault();

                System.Diagnostics.Debug.WriteLine("user_id: " + userId);
                System.Diagnostics.Debug.WriteLine("start_time: " + date + " " + showTime);
                System.Diagnostics.Debug.WriteLine("movie_id: " + movieId);
                System.Diagnostics.Debug.WriteLine("showtime_id: " + st.showtime_id);


                // Tạo đối tượng Booking để lưu vào database
                var booking = new Booking
                {
                    user_id = userId,
                    booking_date = DateTime.Parse(date),
                    showtime_id = st.showtime_id,
                    total_amount = totalPrice
                };
                db.Bookings.Add(booking);
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("booking_id: " + booking.booking_id);

                foreach (var seat in selectedSeats)
                {
                    string s_row = seat[0].ToString();
                    int s_num = int.Parse(seat[1].ToString());
                    Seat s = db.Seats.Where(p => p.seat_row == s_row && p.seat_number == s_num && p.screen_id == screenId).SingleOrDefault();
                    System.Diagnostics.Debug.WriteLine("seat num: " + s_num);
                    System.Diagnostics.Debug.WriteLine("seat row: " + s_row);

                    System.Diagnostics.Debug.WriteLine("seat_id: " + s.seat_id);
                    decimal price = 150000;
                    if (s_num > 5 && s_num < 10)
                    {
                        price = 200000;
                    }

                    Booking_Details bd = new Booking_Details
                    {
                        booking_id = booking.booking_id,
                        seat_id = s.seat_id,
                        price = price
                    };
                    db.Booking_Details.Add(bd);
                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("booking_detail_id: " + bd.booking_detail_id);
                }
                return Json(new
                {
                    success = true,
                    message = "Đặt vé thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Đã có lỗi xảy ra: " + ex.Message
                });
            }
        }


        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }


        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.showtime_id = new SelectList(db.Showtimes, "showtime_id", "showtime_id");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_id,user_id,showtime_id,booking_date,total_amount")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.showtime_id = new SelectList(db.Showtimes, "showtime_id", "showtime_id", booking.showtime_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username", booking.user_id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.showtime_id = new SelectList(db.Showtimes, "showtime_id", "showtime_id", booking.showtime_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username", booking.user_id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,user_id,showtime_id,booking_date,total_amount")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.showtime_id = new SelectList(db.Showtimes, "showtime_id", "showtime_id", booking.showtime_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username", booking.user_id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
           
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult History(int customerId)
        {
            var history = (from b in db.Bookings
                           join bd in db.Booking_Details on b.booking_id equals bd.booking_id
                           join m in db.Movies on b.showtime_id equals m.movie_id
                           where b.user_id == customerId
                           group new { b, bd, m } by new
                           {
                               b.booking_id,
                               m.movie_id,
                               b.total_amount,
                               b.booking_date
                           } into g
                           select new
                           {
                               BookingID = g.Key.booking_id,
                               MovieName = g.Key.movie_id,
                               TotalPrice = g.Key.total_amount,
                               BookingDate = g.Key.booking_date,
                               SeatCount = g.Sum(x => x.bd.seat_id)
                           }).ToList();

            return View(history);
        }

        public ActionResult FailureView()
        {
            return View();
        }
        public ActionResult SuccessView()
        {
            return View();
        }
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Bookings/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }
        private PayPal.Api.Payment payment;
        private PayPal.Api.Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new PayPal.Api.Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private PayPal.Api.Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Item Name comes here",
                currency = "USD",
                price = "1",
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = "3", // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            var paypalOrderId = DateTime.Now.Ticks;
            transactionList.Add(new Transaction()
            {
                description = $"Invoice #{paypalOrderId}",
                invoice_number = paypalOrderId.ToString(), //Generate an Invoice No    
                amount = amount,
                item_list = itemList
            });
            this.payment = new PayPal.Api.Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }


    }
}


