using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.ViewModels
{
    public class _EnrollmentStudentEnrollmentViewModel
    {
        public _EnrollmentStudentEnrollmentViewModel()
        {
            EnrolledPrograms = new List<Program>();
            EnrolledSemesters = new List<Semester>();

            OtherPrograms = new List<Program>();
            OtherSemesters = new List<Semester>();

            Enrollments = new List<Enrollment>();

        }
        public Program CurrentProgram { get; set; }

        public Semester CurrentSemester { get; set; }

        public List<Program> EnrolledPrograms { get; set; }
        public List<Semester> EnrolledSemesters { get; set; }

        public List<Program> OtherPrograms { get; set; }
        public List<Semester> OtherSemesters { get; set; }

        public List<Enrollment> Enrollments { get; set; }


    }
}