using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class StudentPlan
    {
        public int StudentPlanId { get; set; }

        public int EnrollmentId { get; set; }

        [ForeignKey("Student")]
        [Required]
        public int StudentId { get; set; }

        [ForeignKey("Course")]

        //[Display(Name ="Course")]
        [DisplayName("Course")]
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("Semester")]
        [Required]
        public int SemesterId { get; set; }

        [ForeignKey("Program")]
        [Required]
        public int ProgramId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Program Program { get; set; }
    }
}