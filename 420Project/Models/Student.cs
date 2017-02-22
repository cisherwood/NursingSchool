using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string MiddleName { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public string Email { get; set; }

        [StringLength(15, MinimumLength = 1)]
        public string PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Address { get; set; }
        public int AdvisorId { get; set; }
        public int ProgramId { get; set; }
        public bool HasGraduated { get; set; }

        [StringLength(5, MinimumLength = 1)]
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