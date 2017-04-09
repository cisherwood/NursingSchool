using _420Project.Models;
using _420Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _420Project.Controllers
{
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();




        // GET: Dashboard/Index
        public ActionResult Index()
        {
            //ViewModel initialization
            List<ToDo> DashboardViewModelToDos = new List<ToDo>();
            List<Notification> DashboardViewModelNotifications = new List<Notification>();
            List<Event> DashboardViewModelEvents = new List<Event>();
            int DashboardViewModelStudentsOutofCompliance = 0;
            int DashboardViewModelEnrolledStudents = 0;
            int DashboardViewModelDaysToSemesterEnd = 0;
            string CurrentUserId = Session["CurrentUserId"].ToString();

            // ToDos
            List<UserToDo> DashboardUserToDos = new List<UserToDo>();
            DashboardUserToDos = db.UserToDos.Where(x => x.UserId == CurrentUserId).Where(x => x.isComplete == false).ToList();

            foreach (UserToDo DashboardUserToDo in DashboardUserToDos)
            {
                DashboardViewModelToDos.Add(db.To_Dos.Where(x => x.ToDoID == DashboardUserToDo.ToDoId).FirstOrDefault());
            }

            // Notifications
            List<UserNotification> DashboardUserNotifications = new List<UserNotification>();
            DashboardUserNotifications = db.UserNotifications.Where(x => x.UserId == CurrentUserId).Where(x => x.isComplete == false).ToList();

            foreach (UserNotification DashboardUserNotification in DashboardUserNotifications)
            { 

                DashboardViewModelNotifications.Add(db.Notifications.Where(x => x.NotificationId == DashboardUserNotification.NotificationId).FirstOrDefault());
            }

            // Events
            // Prod - just Upcoming events
            List<UserEvent> DashboardUserEvents = new List<UserEvent>();
            DashboardUserEvents = db.UserEvents.Where(x => x.UserId == CurrentUserId).ToList();

            foreach (UserEvent DashboardUserEvent in DashboardUserEvents)
            {

                DashboardViewModelEvents.Add(db.Event.Where(x => x.EventId == DashboardUserEvent.EventId).FirstOrDefault());
            }

            var EnrolledStudentsQuery = db.Student.Count(); //Fix this for production


            DashboardViewModel dashboardViewModel = new DashboardViewModel()
            {
                studentsoutofcompliance = 3,
                EnrolledStudents = EnrolledStudentsQuery,
                AverageGPA = 2.5,
                DaysToSemesterEnd = 3,
                ToDo = DashboardViewModelToDos,
                Notifications = DashboardViewModelNotifications,
                Event = DashboardViewModelEvents,
                NotCount = DashboardViewModelNotifications.Count(),
                EventCount = DashboardViewModelEvents.Count(),
                ToDoCount = DashboardViewModelToDos.Count()
            };
            return View(dashboardViewModel);
        }

        // GET: Dashboard/Index
        public ActionResult Development()
        {
            return View();
        }

        public ActionResult _NotificationDetail()
        {
            return View();
        }

        public ActionResult _ToDoDetail()
        {
            return View();
        }

        public ActionResult _EventDetail()
        {
            return View();
        }
    }
}