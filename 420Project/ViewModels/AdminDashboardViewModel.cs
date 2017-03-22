using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int StudentsOutofComplianceCount { get; set; }
        public int EnrolledStudentCount { get; set; }
        public double AverageGPA { get; set; }
        public int  DaysUntilSemesterIsOver { get; set; }
        //public ICollection<Notification> Notifications { get; set; }
        public ICollection<ToDo> ToDos { get; set; }

        public ICollection<Event> Events { get; set; }
     }
}