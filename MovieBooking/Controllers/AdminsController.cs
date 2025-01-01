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
    public class AdminsController : Controller
    {
        private BookingModel db = new BookingModel();

        // GET: Admins
        public ActionResult Index()
        {
            return RedirectToAction("index","Movies");
        }
        
        public ActionResult BillTracking()
        {
            var bookings = db.Bookings.Include(b => b.Showtime).Include(b => b.User);
            return View(bookings.ToList());
        }
        public ActionResult Details_booking(int? id)
        {
            var details = db.Booking_Details.Where(p => p.booking_id == id);
            return View(details.ToList());
        }

        [HttpPost]
        
        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            var details = db.Booking_Details.Where(p => p.booking_id == id);
            //if (details == null)
            //{
            //    return HttpNotFound();
            //}
            return View(details.ToList());
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmId,Username,Pass,FullName,Bod,Address,Phone,Email")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmId,Username,Pass,FullName,Bod,Address,Phone,Email")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
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
