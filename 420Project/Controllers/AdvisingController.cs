using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class AdvisingController : Controller
    {
        // GET: Advising
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Advising()
        {
            return View();
        }

        public ActionResult Compliance()
        {
            return View();
        }

        public ActionResult Program()
        {
            return View();
        }

        public ActionResult Plan()
        {
            return View();
        }

        public ActionResult Petition()
        {
            return View();
        }

        public ActionResult ViewDocument()
        {
            return View();
        }

        public ActionResult ComplianceEdit()
        {
            StudentCompliance model = new StudentCompliance();

            model.ComplianceId = 1;
            model.ExpirationDate = new DateTime(2017, 1, 1);
            model.SCId = 1;
            model.StudentId = 1;
            model.SubmissionDate = new DateTime(2017, 1, 1);

            return View(model);
        }
    }
}