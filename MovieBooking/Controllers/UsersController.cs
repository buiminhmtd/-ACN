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
    public class UsersController : Controller
    {
        private BookingModel db = new BookingModel();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Login()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            var adminAcc = db.Admins
                 .Where(a => a.Username == user && a.Pass == pass)
                 .SingleOrDefault();

            if (adminAcc != null)
            {
                // Nếu tài khoản tồn tại trong bảng Admin, thiết lập session cho Admin và điều hướng
                Session["user"] = user;
                Session["role"] = "admin";
                return RedirectToAction("Index", "Admins");
            }

            var acc = db.Users.Where(a => (a.username == user && a.password == pass)).SingleOrDefault();

            if (acc != null)
            {
                Session["user"] = user;
                Session["userName"] = acc.username;
                Session["userEmail"] = acc.email;
                Session["userPhone"] = acc.phone_number;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.err = "sai tên đăng nhập hoặc mật khẩu!!\n";
                return View();
            }

        }
        public ActionResult SignUp()
        {
            System.Diagnostics.Debug.WriteLine("Giá trị của biến x: " + 10);
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string user, string email, string phone, string pass, string confirm)
        {
            System.Diagnostics.Debug.WriteLine("Giá trị của biến x: " + 0);
            if (pass != confirm )
            {
                System.Diagnostics.Debug.WriteLine("Giá trị của biến x: " + 1);
                ViewBag.err = "Xác nhận mật khẩu không khớp!!";
                return View();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Giá trị của biến x: " + 2);
                User user1 = new User();
                user1.phone_number = phone;
                user1.email = email;
                user1.password = pass;
                user1.username = user;
                db.Users.Add(user1);
                db.SaveChanges();
                return RedirectToAction("Login", "Users");

            }
        }
        public ActionResult Logout()
        {
            // Xóa tất cả session khi người dùng đăng xuất
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }


        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,username,password,email,phone_number")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,username,password,email,phone_number")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
