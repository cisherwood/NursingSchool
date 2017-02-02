using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Models
{
    public class Semester
    {
        public string SemesterString()
        {
            return this.Season + this.Year.ToString();
        }
        public int SemesterId { get; set; }
        public int Year { get; set; }
        public string Season { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}