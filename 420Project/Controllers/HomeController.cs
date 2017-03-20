using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _420Project.Models;

namespace _420Project.Controllers
{
    public class HomeController : Controller
    {
        // Database context object (
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Session["CurrentSemesterId"] = 3;
            Semester current = db.Semester.SingleOrDefault(x => x.SemesterId == 3);

             Session["CurrentSemesterString"] = current.Season + " " + current.Year.ToString();

            return RedirectToAction("Login", "Account", new {
                returnUrl = "/Dashboard/Index"
            });
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

    }
}