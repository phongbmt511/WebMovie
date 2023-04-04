using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;

namespace DoAnWeb.Views
{
    public class C_movieController : Controller
    {
        private webmovieEntities db = new webmovieEntities();

        // GET: C_movie
        public ActionResult Index()
        {
            var c_movie = db.C_movie.Include(c => c.category);
            return View(c_movie.ToList());
        }

        // GET: C_movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_movie c_movie = db.C_movie.Find(id);
            if (c_movie == null)
            {
                return HttpNotFound();
            }
            return View(c_movie);
        }

        // GET: C_movie/Create
        public ActionResult Create()
        {
            ViewBag.categoryid = new SelectList(db.categories, "categoryId", "categoryName");
            return View();
        }

        // POST: C_movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movieId,movieName,movieContent,premiereDate,moviePhotoLink,banerLink,trailerLink,review,categoryid")] C_movie c_movie)
        {
            if (ModelState.IsValid)
            {
                db.C_movie.Add(c_movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryid = new SelectList(db.categories, "categoryId", "categoryName", c_movie.categoryid);
            return View(c_movie);
        }

        // GET: C_movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_movie c_movie = db.C_movie.Find(id);
            if (c_movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryid = new SelectList(db.categories, "categoryId", "categoryName", c_movie.categoryid);
            return View(c_movie);
        }

        // POST: C_movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "movieId,movieName,movieContent,premiereDate,moviePhotoLink,banerLink,trailerLink,review,categoryid")] C_movie c_movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c_movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryid = new SelectList(db.categories, "categoryId", "categoryName", c_movie.categoryid);
            return View(c_movie);
        }

        // GET: C_movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_movie c_movie = db.C_movie.Find(id);
            if (c_movie == null)
            {
                return HttpNotFound();
            }
            return View(c_movie);
        }

        // POST: C_movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C_movie c_movie = db.C_movie.Find(id);
            db.C_movie.Remove(c_movie);
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
