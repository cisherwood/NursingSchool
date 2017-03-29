using _420Project.Models;
using _420Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();




        // GET: Dashboard/Index
        public ActionResult Index()
        {

            var EnrolledStudentsQuery = db.Student.Where(x => x.Status == "Enrolled").Count();


            DashboardViewModel dashboardViewModel = new DashboardViewModel()
            {
                studentsoutofcompliance = 3,
                EnrolledStudents = EnrolledStudentsQuery,
                AverageGPA = 2.5,
                DaysToSemesterEnd = 3,
            };
            return View(dashboardViewModel);
        }

        // GET: Dashboard/Index
        public ActionResult Development()
        {
            return View();
        }

        public ActionResult EventDetail()
        {
            return View();
        }

        public ActionResult ManageStudents()
        {
            return View();
        }

        public ActionResult ManageEvents()
        {
            return View();
        }
    }
}