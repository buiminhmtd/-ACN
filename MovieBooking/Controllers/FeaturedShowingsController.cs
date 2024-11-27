using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBooking.Controllers
{
    public class FeaturedShowingsController : Controller
    {
        private BookingModel db = new BookingModel();


        // GET: FeaturedShowings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSlide()
        {
            // Lấy danh sách phim để hiển thị trong dropdown
            var model = new FeaturedShowingsViewModel
            {
                MoviesList = db.Movies.ToList() // Lấy danh sách phim từ database
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult AddSlide(FeaturedShowingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tạo một đối tượng slide mới
                var newSlide = new Featured_Showings
                {
                    movie_id = model.movie_id,
                    start_date = model.start_date,
                    end_date = model.end_date,
                    is_active = model.is_active
                };

                // Lưu vào cơ sở dữ liệu
                db.Featured_Showings.Add(newSlide);
                db.SaveChanges();

                return RedirectToAction("ManageSlides"); // Điều hướng về danh sách slide
            }

            // Nếu dữ liệu không hợp lệ, nạp lại danh sách phim
            model.MoviesList = db.Movies.ToList();
            return View(model);
        }


        public ActionResult EditSlide(int id)
        {
            // Lấy slide từ database dựa trên id
            var slide = db.Featured_Showings.FirstOrDefault(s => s.feature_id == id);
            if (slide == null)
            {
                return HttpNotFound("Slide không tồn tại.");
            }

            // Lấy danh sách phim để hiển thị trong dropdown
            var movies = db.Movies.ToList();

            // Tạo ViewModel
            var model = new FeaturedShowingsViewModel
            {
                feature_id = slide.feature_id,
                movie_id = slide.movie_id,
                start_date = slide.start_date,
                end_date = slide.end_date,
                is_active = slide.is_active,
                MoviesList = movies // Danh sách phim cho dropdown
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult EditSlide(FeaturedShowingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm slide cần sửa
                var slide = db.Featured_Showings.FirstOrDefault(s => s.feature_id == model.feature_id);
                if (slide == null)
                {
                    return HttpNotFound("Slide không tồn tại.");
                }

                // Cập nhật thông tin
                slide.movie_id = model.movie_id;
                slide.start_date = model.start_date;
                slide.end_date = model.end_date;
                slide.is_active = model.is_active;

                db.SaveChanges();

                return RedirectToAction("ManageSlides");
            }

            // Nếu dữ liệu không hợp lệ, nạp lại danh sách phim
            model.MoviesList = db.Movies.ToList();
            return View(model);
        }


        public ActionResult DeleteSlide(int id)
        {
            var slide = db.Featured_Showings.FirstOrDefault(s => s.feature_id == id);
            if (slide != null)
            {
                db.Featured_Showings.Remove(slide);
                db.SaveChanges();
            }

            return RedirectToAction("ManageSlides");
        }

        public ActionResult ManageSlides()
        {
            // Lấy danh sách các slide (Featured_Showings)
            var slides = db.Featured_Showings.ToList();

            // Lấy danh sách tất cả các phim (Movies)
            var movies = db.Movies.ToList();

            // Kết hợp dữ liệu của Featured_Showings với tên phim từ Movies
            var viewModel = slides.Select(slide => new FeaturedShowingsViewModel
            {
                feature_id = slide.feature_id,
                movie_id = slide.movie_id,
                start_date = slide.start_date,
                end_date = slide.end_date,
                is_active = slide.is_active,
                movie_title = slide.movie_id != 0
                      ? movies.FirstOrDefault(m => m.movie_id == slide.movie_id)?.title
                      : "No Title"  // Kiểm tra nếu movie_id không phải là 0
            }).ToList();

            return View(viewModel);
        }






    }
}