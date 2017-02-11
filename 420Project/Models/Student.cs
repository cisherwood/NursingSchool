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

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }




    }
}