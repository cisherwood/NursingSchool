using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CourseString { get { return this.Department.Name + " " + this.Number; } }

        public virtual Department Department { get; set; }

        public virtual ICollection<ProgramCourse> ProgramCourse { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}