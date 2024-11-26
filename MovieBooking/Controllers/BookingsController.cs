using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieBooking.Models;

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
    }
}
