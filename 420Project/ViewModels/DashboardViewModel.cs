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

    }
}