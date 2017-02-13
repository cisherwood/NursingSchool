using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasGraduated { get; set; }
        public int CampusID { get; set; }

        
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }




    }
}