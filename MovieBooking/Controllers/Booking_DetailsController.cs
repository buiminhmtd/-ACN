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
    public class Booking_DetailsController : Controller
    {
        private BookingModel db = new BookingModel();

        // GET: Booking_Details
        public ActionResult Index()
        {
            var booking_Details = db.Booking_Details.Include(b => b.Booking).Include(b => b.Seat);
            return View(booking_Details.ToList());
        }

        // GET: Booking_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking_Details booking_Details = db.Booking_Details.Find(id);
            if (booking_Details == null)
            {
                return HttpNotFound();
            }
            return View(booking_Details);
        }

        // GET: Booking_Details/Create
        public ActionResult Create()
        {
            ViewBag.booking_id = new SelectList(db.Bookings, "booking_id", "booking_id");
            ViewBag.seat_id = new SelectList(db.Seats, "seat_id", "seat_row");
            return View();
        }

        // POST: Booking_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_detail_id,booking_id,seat_id,price")] Booking_Details booking_Details)
        {
            if (ModelState.IsValid)
            {
                db.Booking_Details.Add(booking_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.booking_id = new SelectList(db.Bookings, "booking_id", "booking_id", booking_Details.booking_id);
            ViewBag.seat_id = new SelectList(db.Seats, "seat_id", "seat_row", booking_Details.seat_id);
            return View(booking_Details);
        }

        // GET: Booking_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking_Details booking_Details = db.Booking_Details.Find(id);
            if (booking_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.booking_id = new SelectList(db.Bookings, "booking_id", "booking_id", booking_Details.booking_id);
            ViewBag.seat_id = new SelectList(db.Seats, "seat_id", "seat_row", booking_Details.seat_id);
            return View(booking_Details);
        }

        // POST: Booking_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_detail_id,booking_id,seat_id,price")] Booking_Details booking_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.booking_id = new SelectList(db.Bookings, "booking_id", "booking_id", booking_Details.booking_id);
            ViewBag.seat_id = new SelectList(db.Seats, "seat_id", "seat_row", booking_Details.seat_id);
            return View(booking_Details);
        }

        // GET: Booking_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking_Details booking_Details = db.Booking_Details.Find(id);
            if (booking_Details == null)
            {
                return HttpNotFound();
            }
            return View(booking_Details);
        }

        // POST: Booking_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking_Details booking_Details = db.Booking_Details.Find(id);
            db.Booking_Details.Remove(booking_Details);
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
    }
}
