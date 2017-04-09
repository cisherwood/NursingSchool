using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Student()
        {
            return View();
        }

        public ActionResult _Course()
        {
            return View();
        }

        public ActionResult _Program()
        {
            return View();
        }
    }
}