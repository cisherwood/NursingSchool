using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.ViewModels
{
    public class _EnrollmentStudentEnrollViewModel
    {
        public _EnrollmentStudentEnrollViewModel()
        {
            Courses = new List<_EnrollmentStudentEnrollModel>();
            AllCourses = new List<Course>();

        }

        public List<_EnrollmentStudentEnrollModel> Courses { get; set; }

        public List<Course> AllCourses { get; set; }



    }

    public class _EnrollmentStudentEnrollModel
    {

        public int? CourseId { get; set; }

        public bool HasTaken { get; set; }

        public bool IsProgramCourse { get; set; }

        public string Grade { get; set; }

        public double QPts { get; set; }

        public bool IsTransferCredit { get; set; }


        public virtual Course CourseData { get; set; }
    }
}