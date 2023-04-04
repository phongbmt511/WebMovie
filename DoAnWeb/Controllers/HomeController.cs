using DoAnWeb.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;


namespace DoAnWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string SearchString = "")
        {
           webmovieEntities db = new webmovieEntities();
           List<C_movie> mv = db.C_movie.ToList();
            if (SearchString != "")
            {
                var c_movie = db.C_movie.Where(t => t.movieName.ToUpper().Contains(SearchString.ToUpper()));
                return View(c_movie.ToList());
            }
            return View(mv);   
        }

        public ActionResult About(int id)
        {
            webmovieEntities db = new webmovieEntities();
            C_movie ph = db.C_movie.Where(x => x.categoryid == id).FirstOrDefault();
            ViewBag.Movie = db.Staff_.ToList();
            ViewBag.TT = db.C_movie.Where(a => a.movieId == id).ToList();
            return View(ph);   
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}