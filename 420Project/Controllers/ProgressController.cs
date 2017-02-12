using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _420Project.Models;
using _420Project.ViewModels;

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

            // Set selected semester ID
            Session["ProgresStudentCurrentSemester"] = currentSemesterId;

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

            // Set selected semester ID
            Session["ProgresStudentCurrentSemester"] = sem;

            // Get enrollment data about selected student
            List<Enrollment> enrollments = new List<Enrollment>(from en in db.Enrollment
                                                                where en.StudentId == currentStudentId &&
                                                                      en.SemesterId == sem
                                                                select en);

            return View(enrollments);
        }

        //AJAX
        // Get class
        public ActionResult StudentGetAddCourses(int? sem)
        {
            // List of classes
            List<Course> courses = db.Course.ToList();

            int currentStudent = Convert.ToInt32(Session["ProgressStudentCurrentStudent"]);
            int currentSemester = Convert.ToInt32(Session["ProgresStudentCurrentSemester"]);

            List<ProgressStudentAddCourseViewModel> vm = new List<ProgressStudentAddCourseViewModel>();

            foreach (Course c in courses)
            {
                ProgressStudentAddCourseViewModel course = new ProgressStudentAddCourseViewModel();
                course.CourseId = c.CourseId;
                course.Number = c.Number;
                course.Title = c.Title;
                course.Description = c.Description;
                course.Department = c.Department;
                course.IsChecked = db.Enrollment.Any(x => x.CourseId == c.CourseId && x.SemesterId == currentSemester && x.StudentId == currentStudent);
                course.HasTaken = db.Enrollment.Any(x => x.CourseId == c.CourseId && x.StudentId == currentStudent);

                vm.Add(course);

            }

            return View(vm);
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


    }
}