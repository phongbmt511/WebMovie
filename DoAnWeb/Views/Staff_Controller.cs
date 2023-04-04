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
    public class Staff_Controller : Controller
    {
        private webmovieEntities db = new webmovieEntities();

        // GET: Staff_
        public ActionResult Index()
        {
            var staff_ = db.Staff_.Include(s => s.C_movie);
            return View(staff_.ToList());
        }

        // GET: Staff_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_ staff_ = db.Staff_.Find(id);
            if (staff_ == null)
            {
                return HttpNotFound();
            }
            return View(staff_);
        }

        // GET: Staff_/Create
        public ActionResult Create()
        {
            ViewBag.movieid = new SelectList(db.C_movie, "movieId", "movieName");
            return View();
        }

        // POST: Staff_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staffid,staffName,birthday,country,gender,staffPhotoLink,movieid")] Staff_ staff_)
        {
            if (ModelState.IsValid)
            {
                db.Staff_.Add(staff_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.movieid = new SelectList(db.C_movie, "movieId", "movieName", staff_.movieid);
            return View(staff_);
        }

        // GET: Staff_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_ staff_ = db.Staff_.Find(id);
            if (staff_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.movieid = new SelectList(db.C_movie, "movieId", "movieName", staff_.movieid);
            return View(staff_);
        }

        // POST: Staff_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staffid,staffName,birthday,country,gender,staffPhotoLink,movieid")] Staff_ staff_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.movieid = new SelectList(db.C_movie, "movieId", "movieName", staff_.movieid);
            return View(staff_);
        }

        // GET: Staff_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_ staff_ = db.Staff_.Find(id);
            if (staff_ == null)
            {
                return HttpNotFound();
            }
            return View(staff_);
        }

        // POST: Staff_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff_ staff_ = db.Staff_.Find(id);
            db.Staff_.Remove(staff_);
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
