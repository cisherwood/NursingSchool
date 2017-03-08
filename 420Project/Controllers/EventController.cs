using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {

            return View();
        }

        // GET: Event
        public ActionResult Detail(int id)
        {

            return View();
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Edit()
        {

            return View();
        }
    }
}