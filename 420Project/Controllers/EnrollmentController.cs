using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class EnrollmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enrollment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Student(List<int> studentIDList)
        {
            List<Student> studentList = new List<Student>();

            if (studentIDList != null)
            {
                foreach (int id in studentIDList)
                {
                    studentList.Add((db.Student.Where(x => x.StudentId == id)).SingleOrDefault());
                }
            }
            else
            {
                studentList = db.Student.Where(x => x.StudentId != 0).ToList(); //Change to only enrolled students.
            }

            return View(studentList);
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