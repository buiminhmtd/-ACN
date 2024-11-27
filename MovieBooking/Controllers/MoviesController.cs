using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Web.UI.WebControls;
using MovieBooking.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;
using System.Web.UI;

namespace MovieBooking.Controllers
{
    public class MoviesController : Controller
    {

        private BookingModel db = new BookingModel();



        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult MovieList()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }


        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult MovieDetails(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Lấy thông tin bộ phim
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            // Lấy danh sách bình luận (giới hạn 5 bình luận mỗi trang)
            var comments = db.Feedbacks
                .Where(f => f.movie_id == id)
                .OrderByDescending(f => f.feedback_date)
                .Skip((page - 1) * 5)  // Bắt đầu từ trang 1
                .Take(5)  // Lấy tối đa 5 bình luận
                .ToList();

            // Kiểm tra xem người dùng đã đặt vé chưa
            int userId;
            bool hasBookedTicket;
            if (int.TryParse(User.Identity.Name, out userId))
            {
                hasBookedTicket = db.Bookings
                    .Join(db.Showtimes, b => b.showtime_id, s => s.showtime_id, (b, s) => new { b, s })
                    .Any(bs => bs.s.movie_id == id && bs.b.user_id == userId);
            }
            else
            {
                // Nếu không chuyển được User.Identity.Name sang kiểu int, xem như người dùng chưa đăng nhập hoặc ID không hợp lệ
                hasBookedTicket = false;
            }

            // Tạo ViewModel và truyền vào View
            var viewModel = new MovieDetailsViewModel
            {
                Movie = movie,
                HasBookedTicket = hasBookedTicket,
                Feedbacks = comments
            };

            return View(viewModel);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movie_id,title,description,duration,genre,release_date,image_url")] Movie movie, HttpPostedFileBase image_url)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu có tệp hình ảnh được tải lên
                if (image_url != null && image_url.ContentLength > 0)
                {
                    // Tạo tên tệp duy nhất để tránh trùng lặp
                    var fileName = Path.GetFileName(image_url.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/Images"), fileName);

                    // Lưu tệp ảnh vào thư mục
                    image_url.SaveAs(filePath);

                    // Lưu URL của ảnh vào thuộc tính model
                    movie.image_url = "/Content/Images/" + fileName;
                }

                // Thêm movie vào cơ sở dữ liệu và lưu
                db.Movies.Add(movie);
                db.SaveChanges();

                // Chuyển hướng về trang danh sách phim
                return RedirectToAction("Index");
            }

            // Nếu model không hợp lệ, hiển thị lại form
            return View(movie);
        }


        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "movie_id,title,description,duration,genre,release_date,image_url")] Movie movie, HttpPostedFileBase image_url)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu người dùng tải lên ảnh mới
                if (image_url != null && image_url.ContentLength > 0)
                {
                    // Xóa ảnh cũ (nếu cần) và lưu ảnh mới
                    var fileName = Path.GetFileName(image_url.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    image_url.SaveAs(path);

                    movie.image_url = "/Content/Images/" + fileName;
                }
                // Cập nhật thông tin phim trong cơ sở dữ liệu
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(movie);
        }


        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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


        // Xử lý gửi bình luận
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(int movieId, string comment)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Nếu người dùng chưa đăng nhập, thông báo lỗi
                TempData["ErrorMessage"] = "Bạn phải đăng nhập để gửi bình luận.";
                return RedirectToAction("MovieDetails", new { id = movieId });
            }

            int userId;
            bool hasBookedTicket;
            if (int.TryParse(User.Identity.Name, out userId))
            {
                hasBookedTicket = db.Bookings
                    .Join(db.Showtimes, b => b.showtime_id, s => s.showtime_id, (b, s) => new { b, s })
                    .Any(bs => bs.s.movie_id == movieId && bs.b.user_id == userId);
            }
            else
            {
                // Nếu không chuyển được User.Identity.Name sang kiểu int, xem như người dùng chưa đăng nhập hoặc ID không hợp lệ
                hasBookedTicket = false;
            }

            // Kiểm tra nếu người dùng đã đặt vé xem phim
            

            if (!hasBookedTicket)
            {
                // Nếu chưa đặt vé, thông báo lỗi
                TempData["ErrorMessage"] = "Bạn phải xem phim trước khi bình luận.";
                return RedirectToAction("MovieDetails", new { id = movieId });
            }

            // Tạo và lưu bình luận mới
            var feedback = new Feedback
            {
                user_id = int.Parse(User.Identity.Name),
                movie_id = movieId,
                comments = comment,
                feedback_date = DateTime.Now
            };

            db.Feedbacks.Add(feedback);
            db.SaveChanges();

            // Thông báo thành công
            TempData["SuccessMessage"] = "Bình luận của bạn đã được gửi thành công!";
            return RedirectToAction("MovieDetails", new { id = movieId });
        }
    }

}


