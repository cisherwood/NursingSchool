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
        // Course column of progress area
        public ActionResult ProgressStudentCourses(int id)
        {
            // Get current semester ID from session variable
            int currentSemesterId = Convert.ToInt32(Session["CurrentSemesterId"]);

            // Get enrollment data about selected student
            List<Enrollment> enrollments = new List<Enrollment>(from en in db.Enrollment
                                                                where en.StudentId == id
                                                                select en);

            // List of semesters that the selected student has taken classes
            ViewBag.StudentSemesters = enrollments.Where(x => x.SemesterId != currentSemesterId).Select(x => x.Semester).Distinct();

            // List of classes in the current semester
            ViewBag.StudentCurrentClasses = enrollments.Where(x => x.SemesterId == currentSemesterId).Select(x => x.Course);



            return View("~/Views/Application/Progress/ProgressStudentCourses.cshtml", enrollments);
        }


        public ActionResult ProgressStudentCoursesCurrent(int id, int sem)
        {
            List<Enrollment> enrollments = new List<Enrollment>(from en in db.Enrollment
                                                                where en.StudentId == id &&
                                                                      en.SemesterId == sem
                                                                select en);

            ViewBag.StudentSemesters = enrollments.Select(x => x.Semester).Distinct();

            return View("~/Views/Application/Progress/ProgressStudentCoursesCurrent.cshtml", enrollments);
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