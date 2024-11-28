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
    }
}