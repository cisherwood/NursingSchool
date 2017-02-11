using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _420Project.Models;

namespace _420Project.Controllers
{
    public class ProgressController : Controller
    {
        // Database context object
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Progress
        public ActionResult Index()
        {
            return View();
        }

        // AJAX
        // Student column of progress area
        public ActionResult Student()
        {
            // Get list of students from database
            List<Student> students = new List<Student>(from student in db.Student
                                                       select student);
            // Return view with list of students
            return View(students);
        }

        // AJAX
        // Registerd course column of progress area
        public ActionResult StudentCourses(int id)
        {
            // Set selected student to session variable
            Session["ProgressStudentCurrentStudent"] = id;

            // Get current semester ID from session variable
            int currentSemesterId = Convert.ToInt32(Session["CurrentSemesterId"]);

            ViewBag.currentSemesterId = currentSemesterId;

            // Get enrollment data about selected student
            List<Enrollment> enrollments = new List<Enrollment>(from en in db.Enrollment
                                                                where en.StudentId == id
                                                                select en);

            // List of semesters that the selected student has taken classes
            var semswithoutcurrent = enrollments.Where(x => x.SemesterId != currentSemesterId).Select(x => x.Semester).Distinct().ToList();
            var currentsem = db.Semester.Where(x => x.SemesterId == currentSemesterId).ToList();
            var sems = currentsem.Concat(semswithoutcurrent);
            ViewBag.StudentSemesters = sems;

            // List of classes in the current semester
            ViewBag.StudentCurrentClasses = enrollments.Where(x => x.SemesterId == currentSemesterId).Select(x => x.Course);





            return View(enrollments);
        }

        // AJAX
        // Update course column of progress area with selected semester
        public ActionResult StudentCoursesUpdate(int sem)
        {
            // Get selected student id
            int currentStudentId = Convert.ToInt32(Session["ProgressStudentCurrentStudent"]);

            // Get current semester ID from session variable
            int currentSemesterId = Convert.ToInt32(Session["CurrentSemesterId"]);

            // Get enrollment data about selected student
            List<Enrollment> enrollments = new List<Enrollment>(from en in db.Enrollment
                                                                where en.StudentId == currentStudentId &&
                                                                      en.SemesterId == sem
                                                                select en);

            return View(enrollments);
        }

        // AJAX
        // Add course column of progress area
        public ActionResult StudentCoursesAdd()
        {
            List<Course> courses = new List<Course>(from c in db.Course
                                                    select c);

            ViewBag.ProgressStudentCoursesAdd = courses;

            return View(courses);
        }

        //AJAX
        // Get class
        public ActionResult StudentGetAddCourses(int? sem)
        {
            // List of classes
            List<Course> courses = db.Course.ToList();

            return View(courses);
        }
    }
}