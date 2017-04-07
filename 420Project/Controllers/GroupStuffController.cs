using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class GroupStuffController : Controller
    {
        // GET: GroupStuff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _GroupFilters()
        {



            return View();
        }

        public ActionResult _List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _List(GroupFilter groupFilter)
        {
            return View();
        }
    }
}