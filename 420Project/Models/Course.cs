using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Key]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ClassHours { get; set; }
        public string CourseString { get { return this.Department.Name + " " + this.Number; } }
        public string PassGrade { get; set; }

        [Key]
        [ForeignKey("Campus")]
        public string CampusId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<ProgramCourse> ProgramCourse { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}