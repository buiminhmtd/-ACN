using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieBooking.Models;

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
    }
}
