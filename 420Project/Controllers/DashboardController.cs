using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dashboard/Index
        public ActionResult Development()
        {
            return View();
        }
    }
}