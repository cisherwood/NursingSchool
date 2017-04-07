using _420Project.Models;
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
        public ActionResult _List(GroupFilter GroupFilter)
        {
            //UserType
            if (GroupFilter.UserType == "Student")
            {
                List<Student> students = db.Student.ToList();

                if(!GroupFilter.IsFreshman)
                {
                    students.RemoveAll(x => x.Year == "Freshman");
                }
                if (!GroupFilter.IsSophomore)
                {
                    students.RemoveAll(x => x.Year == "Sophomore");
                }
                if (!GroupFilter.IsJunior)
                {
                    students.RemoveAll(x => x.Year == "Junior");
                }
                if (!GroupFilter.IsSenior)
                {
                    students.RemoveAll(x => x.Year == "Senior");
                }
                if(GroupFilter.AdvisorId != 0)
                {
                    students.RemoveAll(x => x.AdvisorId != GroupFilter.AdvisorId);
                }
                if(GroupFilter.CampusId != 0)
                {
                    students.RemoveAll(x => x.CampusId != GroupFilter.CampusId);
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