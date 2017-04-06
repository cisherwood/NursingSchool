using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.ViewModels
{
    public class DashboardViewModel
    {
        public int studentsoutofcompliance { get; set; }
        public int EnrolledStudents { get; set;}
        public double AverageGPA { get; set; }

        public int DaysToSemesterEnd { get; set; }

        public List <Notification> Notifications { get; set; }

        public List <ToDo> ToDo { get; set; }
        public List <Event> Event { get; set; }

        public int NotCount { get; set; }

        public int ToDoCount{ get; set; }

        public int EventCount { get; set; }


    }
}