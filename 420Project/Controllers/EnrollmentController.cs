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

        public ActionResult _StudentEnrollment(int? studentId, int? programId, int? semesterId)
        {
            int CurrentStudentId;
            int CurrentProgramId;
            int CurrentSemesterId;
            _EnrollmentStudentEnrollmentViewModel vm = new _EnrollmentStudentEnrollmentViewModel();

            if(studentId != null)
            {
                Session["EnrollmentCurrentStudentId"] = studentId;
            }

            CurrentStudentId = Convert.ToInt32(Session["EnrollmentCurrentStudentId"]);

            if(programId == null)
            {
                CurrentProgramId = db.StudentProgram.Where(x => x.StudentId == CurrentStudentId).Where(x => x.Status == "Enrolled").SingleOrDefault().ProgramId;
            }
            else
            {
                CurrentProgramId = Convert.ToInt32(programId);
            }

            if (semesterId == null)
            {
                CurrentSemesterId = db.Semester.OrderByDescending(x => x.EndDate).FirstOrDefault().SemesterId;
            }
            else
            {
                CurrentSemesterId = Convert.ToInt32(semesterId);
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
            foreach (Enrollment s in db.Enrollment.Where(x => x.StudentId == CurrentStudentId).Where(x=>x.StudentProgramId == db.StudentProgram.Where(x=>x.StudentId == CurrentStudentId).Where(x=>x.ProgramId == CurrentProgramId).SingleOrDefault().StudentProgramId).ToList())
            {
                // Add those programs to the program list
                vm.EnrolledSemesters.Add(db.Semester.Where(x => x.SemesterId == s.SemesterId).SingleOrDefault());
            }


            return View();
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