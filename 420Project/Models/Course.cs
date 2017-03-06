using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(15)]
        public string Number { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string CourseString { get { return this.Department.Name + " " + this.Number; } }
        [StringLength(5, MinimumLength = 1)]
        public string PassGrade { get; set; }
        public virtual Department Department { get; set; }
        [StringLength(15)]
        public string CampusId { get; set; }

        public virtual ICollection<ProgramCourse> ProgramCourse { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}