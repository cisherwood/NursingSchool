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
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Advising
        public ActionResult Index()
        {
            var students = db.Student;

            return View(students);

        }
        
        public ActionResult _Students(List<int> studentIDList)
        {
            List<Student> studentList = new List<Student>();

            if (studentIDList == null)
            {
                foreach (int id in studentIDList)
                {
                    studentList.Add((db.Student.Where(x => x.StudentId == id)).SingleOrDefault());
                }
            }

            return View(studentList);
        }

        public ActionResult _StudentDetails(int id)
        {
            Student student = db.Student.Where(x => x.StudentId == id).FirstOrDefault();            

            return View(student);
        }

        //hurr




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