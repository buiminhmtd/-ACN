using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using MovieBooking.Models;
namespace MovieBooking.Controllers
{
    public class HomeController : Controller
    {
        private BookingModel db = new BookingModel();

        public ActionResult Index()
        {
            var slides = db.Featured_Showings
        .Where(s => s.is_active)
        .Select(s => new FeaturedShowingsViewModel
        {
            movie_image_url = s.Movy.image_url,
            movie_title = s.Movy.title
        })
        .ToList();

            return View(slides);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MovieList()
        {
            return View(db.Movies.ToList());

        }
        public ActionResult Search(string query, string genre, DateTime? release_date)
        {
            if (string.IsNullOrEmpty(query) && string.IsNullOrEmpty(genre) && !release_date.HasValue)
            {
                return RedirectToAction("MovieList");
            }

            // Tìm kiếm theo nhiều tiêu chí
            var result = db.Movies.AsQueryable();

            // Tìm kiếm theo tên phim hoặc mô tả
            if (!string.IsNullOrEmpty(query))
            {
                result = result.Where(m => m.title.Contains(query) || m.description.Contains(query));
            }

            // Tìm kiếm theo thể loại
            if (!string.IsNullOrEmpty(genre))
            {
                result = result.Where(m => m.genre.Contains(genre));
            }

            // Tìm kiếm theo năm phát hành
            if (release_date.HasValue)
            {
                result = result.Where(m => m.release_date == release_date.Value);
            }

            // Nếu không có kết quả, thông báo lỗi
            if (!result.Any())
            {
                ViewBag.ErrorMessage = "Không tìm thấy phim nào khớp với từ khóa của bạn.";
            }

            return View("Search", result.ToList());
        }


    }
}