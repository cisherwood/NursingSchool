using _420Project.Models;
using _420Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class GroupStuffController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: GroupStuff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _GroupFilters()
        {



            return View();
        }

        public ActionResult _List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _List(_GroupFilterCompliancesViewModel GroupFilter)
        {

            if(GroupFilter.GroupFilters.UserType == "Potential Student")
            {
                List<Student> students = db.Student.ToList();
                foreach (Student s in students)
                {
                   if(db.StudentProgram.Any(x => x.StudentId != s.StudentId))
                    {
                        students.RemoveAll(x => x.StudentId == s.StudentId);
                    }
                }
            }

            else if(GroupFilter.GroupFilters.UserType == "Advisor")
            {
                List<Advisor> advisors = db.Advisor.ToList();
            }

            else if (GroupFilter.GroupFilters.UserType == "Student")
            {
                List<Student> students = db.Student.ToList();

                if(!GroupFilter.GroupFilters.IsFreshman)
                {
                    students.RemoveAll(x => x.Year == "Freshman");
                }
                if (!GroupFilter.GroupFilters.IsSophomore)
                {
                    students.RemoveAll(x => x.Year == "Sophomore");
                }
                if (!GroupFilter.GroupFilters.IsJunior)
                {
                    students.RemoveAll(x => x.Year == "Junior");
                }
                if (!GroupFilter.GroupFilters.IsSenior)
                {
                    students.RemoveAll(x => x.Year == "Senior");
                }
                if(GroupFilter.GroupFilters.AdvisorId != 0)
                {
                    students.RemoveAll(x => x.AdvisorId != GroupFilter.GroupFilters.AdvisorId);
                }
                if(GroupFilter.GroupFilters.CampusId != 0)
                {
                    students.RemoveAll(x => x.CampusId != GroupFilter.GroupFilters.CampusId);
                }
                if(!GroupFilter.GroupFilters.Petition)
                {
                    foreach(Student s in students)
                    {
                        if(db.StudentPetition.Where(x => x.StudentID != s.StudentId).Any(x=>x.Status == "Pending"))
                        {
                            students.RemoveAll(x => x.StudentId == s.StudentId);
                        }
                    }
                }
                if(GroupFilter.GroupFilters.FilterByCompliance)
                {
                    foreach(Compliance c in db.Compliance)
                    {
                        foreach(Student s in students)
                        {
                            List<StudentCompliance> studentCompliance = db.StudentCompliance.Where(x => x.ComplianceId == c.Id).
                                Where(x=>x.StudentId == s.StudentId).ToList();

                            if (db.StudentCompliance.Any(x => x.ComplianceId == c.Id))
                            {

                            }
                        }
                        
                    }
                }

              
            }
            else
            {
                List<Advisor> advisors = db.Advisor.ToList();


            }

            return View();
        }
    }
}