using _420Project.Models;
using _420Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class AdvisingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Advising
        public ActionResult Index()
        {
            var students = db.Student;
            List<Student> studentList = new List<Student>();
            studentList = db.Student.Where(x => x.StudentId != 0).ToList(); //Change to only enrolled students.
            return View(students);

        }

        public ActionResult _Students(List<int> studentIDList)
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
                studentList = db.Student.Where(x=>x.StudentId != 0).ToList(); //Change to only enrolled students.
            }

            return View(studentList);
        }

        public ActionResult _StudentDetails(int id)
        {
            AdvisingStudentDetailViewModel detailModel = new AdvisingStudentDetailViewModel();

            List<ToDo> ToDos = new List<ToDo>();
            List<Event> events = new List<Event>();
            Student student = db.Student.Where(x => x.StudentId == id).FirstOrDefault();

            Session["AdvisingStudentId"] = id;

            // events = db.To_Dos.Where(x => x.S)

            detailModel.Student = student;


            return View(detailModel);
        }

        public ActionResult _StudentCompliance(int id)
        {
            List<StudentCompliance> compliances = new List<StudentCompliance>();

            compliances = db.StudentCompliance.Where(x => x.StudentId == id).ToList();

            return View(compliances);
        }

        public ActionResult _StudentProgram(int id)
        {
            return View();
        }

        public ActionResult _StudentPlan(int id)
        {
            return View();
        }

        public ActionResult _StudentPetition(int id)
        {
            return View();
        }


        public ActionResult _NotificationDetail(int id)
        {
            return View();
        }

        public ActionResult _ToDoDetail(int id)
        {
            return View();
        }

        public ActionResult _EventDetail(int id)
        {
            return View();
        }

        public ActionResult _StudentNotes(int id)
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