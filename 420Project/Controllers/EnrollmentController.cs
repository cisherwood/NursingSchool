using _420Project.Models;
using _420Project.ViewModels;
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

        SelectList grades = new SelectList(new[]{
          new SelectListItem{ Text="A+", Value="A+"},
          new SelectListItem{ Text="A", Value="A"},
          new SelectListItem{ Text="A-", Value="A-"}
        }, "...", "...", "...");


        // GET: Enrollment
        public ActionResult Index(string EnrollmentType, int? StudentId, int? ProgramId, int? SemesterId)
        {
            ViewBag.EnrollmentType = EnrollmentType;
            ViewBag.StudentId = StudentId;
            ViewBag.ProgramId = ProgramId;
            ViewBag.SemesterId = SemesterId;

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

        public ActionResult _StudentEnrollment(int? studentId, int? programId, int? semesterId)
        {
            int CurrentStudentId;
            int CurrentProgramId;
            int CurrentSemesterId;
            _EnrollmentStudentEnrollmentViewModel vm = new _EnrollmentStudentEnrollmentViewModel();

            if(studentId != null)
            {
                Session["EnrollmentStudentCurrentStudentId"] = studentId;
            }

            CurrentStudentId = Convert.ToInt32(Session["EnrollmentStudentCurrentStudentId"]);

            if(programId != null)
            {
                CurrentProgramId = Convert.ToInt32(programId);
                Session["EnrollmentStudentCurrentProgramId"] = CurrentProgramId;
            }
            else if(Session["EnrollmentStudentCurrentProgramId"] == null) 
            {
                CurrentProgramId = db.StudentProgram.Where(x => x.StudentId == CurrentStudentId).Where(x => x.Status == "Enrolled").SingleOrDefault().ProgramId;
                Session["EnrollmentStudentCurrentProgramId"] = CurrentProgramId;
            }
            else
            {
                CurrentProgramId = Convert.ToInt32(Session["EnrollmentStudentCurrentProgramId"]);
            }

            if (semesterId != null)
            {
                CurrentSemesterId = Convert.ToInt32(semesterId);
                Session["EnrollmentStudentCurrentSemesterId"] = CurrentSemesterId;
            }
            else if (Session["EnrollmentStudentCurrentSemesterId"] == null)
            {
                CurrentSemesterId = db.Semester.OrderByDescending(x => x.EndDate).FirstOrDefault().SemesterId;
                Session["EnrollmentStudentCurrentSemesterId"] = CurrentSemesterId;

            }
            else
            {
                CurrentSemesterId = Convert.ToInt32(Session["EnrollmentStudentCurrentSemesterId"]);
            }

            // Set viewmodel data
            vm.CurrentProgram = db.Program.Where(x => x.ProgramId == CurrentProgramId).FirstOrDefault();
            vm.CurrentSemester = db.Semester.Where(x => x.SemesterId == CurrentSemesterId).FirstOrDefault();

            // Get all programs a student has any status in
            foreach (StudentProgram s in db.StudentProgram.Where(x=>x.StudentId == CurrentStudentId).ToList())
            {
                // Add those programs to the program list
                vm.EnrolledPrograms.Add(db.Program.Where(x=>x.ProgramId == s.ProgramId).SingleOrDefault());
            }

            // Get all semester a student has any enrollment in
            foreach (Enrollment s in db.Enrollment.Where(x => x.StudentId == CurrentStudentId).Where(x=>x.StudentProgramId == db.StudentProgram.Where(z=>z.StudentId == CurrentStudentId).Where(z=>z.ProgramId == CurrentProgramId).FirstOrDefault().StudentProgramId).ToList())
            {
                // Check is the semester has already been added
                if(vm.EnrolledSemesters.Any(x=>x.SemesterId == s.SemesterId))
                {
                    // Add those programs to the program list
                    vm.EnrolledSemesters.Add(db.Semester.Where(x => x.SemesterId == s.SemesterId).SingleOrDefault());
                }

            }

            vm.OtherSemesters = db.Semester.ToList();

            // Get all enrollments that equal current student, current program, and current semester
            vm.Enrollments = db.Enrollment.Where(x => x.StudentId == CurrentStudentId).Where(x => x.SemesterId == CurrentSemesterId).Where(x => x.StudentProgramId == db.StudentProgram.Where(z => z.StudentId == CurrentStudentId).Where(z => z.ProgramId == CurrentProgramId).FirstOrDefault().StudentProgramId).ToList();

            return View(vm);
        }

        public ActionResult _StudentEnroll()
        {
            // Instaniate viewmodel
            _EnrollmentStudentEnrollViewModel vm = new _EnrollmentStudentEnrollViewModel();

            // Get currently select student, semester, and program
            int CurrentStudentId = Convert.ToInt32(Session["EnrollmentStudentCurrentStudentId"]);
            int CurrentSemesterId = Convert.ToInt32(Session["EnrollmentStudentCurrentSemesterId"]);
            int CurrentProgramId = Convert.ToInt32(Session["EnrollmentStudentCurrentProgramId"]);

            /*
            foreach (Course c in db.Course)
            {
                _EnrollmentStudentEnrollModel course = new _EnrollmentStudentEnrollModel();

                // Initalize course data
                course.Course = c;
                course.HasTaken = false;
                course.IsProgramCourse = false;

                // Add course model to viewmodel
                vm.Courses.Add(course);
            }

            ViewBag.Grades = grades;
            */

            vm.AllCourses = db.Course.ToList();
            for (int i = 0; i < 5; i++)
            {
                _EnrollmentStudentEnrollModel m = new _EnrollmentStudentEnrollModel();
                vm.Courses.Add(m);
            }


            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _StudentEnroll(_EnrollmentStudentEnrollViewModel vm)
        {

            // Get currently select student, semester, and program
            int CurrentStudentId = Convert.ToInt32(Session["EnrollmentStudentCurrentStudentId"]);
            int CurrentSemesterId = Convert.ToInt32(Session["EnrollmentStudentCurrentSemesterId"]);
            int CurrentProgramId = Convert.ToInt32(Session["EnrollmentStudentCurrentProgramId"]);

            foreach(_EnrollmentStudentEnrollModel m in vm.Courses)
            {
                if(m.CourseId != null)
                {
                    Enrollment e = new Enrollment();
                    e.CourseId = Convert.ToInt32(m.CourseId);
                    e.Grade = m.Grade;
                    e.IsTransferCredit = m.IsTransferCredit;
                    e.QPts = m.QPts;
                    e.SemesterId = CurrentSemesterId;
                    e.StudentId = CurrentStudentId;
                    e.StudentProgramId = CurrentProgramId;

                    db.Enrollment.Add(e);
                }
            }

            db.SaveChanges();

            return Redirect("/Enrollment/Index?EnrollmentType=Student&StudentId=" + CurrentStudentId + "&ProgramId=" + CurrentProgramId + "&SemesterId=" + CurrentSemesterId);

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