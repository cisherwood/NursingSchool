/* 
Application Controller
*/
using Development.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Development.Controllers
{
    public class ApplicationController : Controller
    {
        // Database context object (
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Application/Index
        // Application Login Page
        public ActionResult Index()

        {
            // ~/Views/Application/Index
            return View();
        }

        // Homepage
        public ActionResult Home()
        {
            // Set session variable to current semester
            Session["CurrentSemesterId"] = 3;
            Semester current = db.Semester.SingleOrDefault(x => x.SemesterId == 3);

            Session["CurrentSemesterString"] = current.Season + " " + current.Year.ToString();

            return View();
        }

        // Progress area homepage
        public ActionResult Progress()
        {
            return View();
        }

        // AJAX
        // Student column of progress area
        public ActionResult ProgressStudent()
        {
            // Get list of students from database
            List<Student> students = new List<Student>(from student in db.Student
                                                       select student);
            // Return view with list of students
            return View("~/Views/Application/Progress/ProgressStudent.cshtml", students);
        }

        // AJAX
        // Registerd course column of progress area
        public ActionResult ProgressStudentCourses(int id)
        {
            // Set selected student to session variable
            Session["ProgressStudentCurrentStudent"] = id;

            // Get current semester ID from session variable
            int currentSemesterId = Convert.ToInt32(Session["CurrentSemesterId"]);

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

            



            return View("~/Views/Application/Progress/ProgressStudentCourses.cshtml", enrollments);
        }


        //AJAX
        // Get class
        public ActionResult ProgressStudentGetAddCourses()
        {
            // List of classes
            List<Course> courses = db.Course.ToList();

            return View("~/Views/Application/Progress/ProgressStudentGetAddCourses.cshtml", courses);
        }

        // AJAX
        // Update course column of progress area with selected semester
        public ActionResult ProgressStudentCoursesUpdate(int sem)
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

            return View("~/Views/Application/Progress/ProgressStudentCoursesUpdate.cshtml", enrollments);
        }

        // AJAX
        // Add course column of progress area
        public ActionResult ProgressStudentCoursesAdd()
        {
            List<Course> courses = new List<Course>(from c in db.Course
                                                                select c);

            ViewBag.ProgressStudentCoursesAdd = courses;

            return View("~/Views/Application/Progress/ProgressStudentCoursesAdd.cshtml", courses);
        }

        

        public ActionResult ProgressStudentTable(int id)
        {
            Session["CurrentStudentId"] = id;
            List<Enrollment> enrollments = new List<Enrollment>(from enrollment in db.Enrollment
                                                                where enrollment.StudentId == id
                                                                select enrollment);

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseString");


            return View("~/Views/Application/Progress/ProgressStudentTable.cshtml", enrollments);
        }

        public ActionResult ProgressStudentTableUpdate()
        {
            int stu_id = Convert.ToInt32(Session["CurrentStudentId"]);
            int sm_id = Convert.ToInt32(Session["CurrentSemesterId"]);
            List<Enrollment> enrollments = new List<Enrollment>(from enrollment in db.Enrollment
                                                                where enrollment.StudentId == stu_id &&
                                                                enrollment.SemesterId == sm_id
                                                                select enrollment);

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number");

            return View("~/Views/Application/Progress/ProgressStudentTableUpdate.cshtml", enrollments);
        }

        public ActionResult ProgressStudentAddEnrollment([Bind(Include = "CourseId")] Enrollment enrollment)
        {
            int stu_id = Convert.ToInt32(Session["CurrentStudentId"]);
            int sm_id = Convert.ToInt32(Session["CurrentSemesterId"]);

            Enrollment enroll = new Enrollment();

            enroll.CourseId  = enrollment.CourseId;
            enroll.SemesterId = sm_id;
            enroll.StudentId = stu_id;

            db.Enrollment.Add(enroll);
            db.SaveChanges();

            List<Enrollment> enrollments = new List<Enrollment>(from en in db.Enrollment
                                                                where en.StudentId == stu_id && 
                                                                      en.SemesterId == sm_id
                                                                select en);

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number");

            return View("~/Views/Application/Progress/ProgressStudentTableUpdate.cshtml", enrollments);
        }

        

        public ActionResult ProgressRoster()
        {
            return View("~/Views/Application/Progress/ProgressRoster.cshtml");
        }

        public ActionResult ProgressProgram()
        {
            return View("~/Views/Application/Progress/ProgressProgram.cshtml");
        }


    }
}