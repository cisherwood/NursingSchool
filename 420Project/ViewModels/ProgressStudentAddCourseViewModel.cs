using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _420Project.Models;

namespace _420Project.ViewModels
{
    public class ProgressStudentAddCourseViewModel
    {
        public int CourseId { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CourseString { get { return this.Department.Name + " " + this.Number; } }
        public bool IsChecked { get; set; }
        public bool HasTaken { get; set; }

        public virtual Department Department { get; set; }


    }
}