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
            return View();
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