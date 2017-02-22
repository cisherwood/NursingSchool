using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AdvisorId { get; set; }
        public int ProgramId { get; set; }
        public bool HasGraduated { get; set; }
        public string Standing { get; set; }
        public string Year { get; set; }
        public DateTime DOB { get; set; }
        public int CampusId { get; set; }

        public string Status { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }




    }
}