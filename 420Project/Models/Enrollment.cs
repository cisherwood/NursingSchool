//Brentan Hudson
//2/24/17
//Enrollment showing courses enrolled in currently

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        [ForeignKey("Student")]
        [Required]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        [Display(Name ="Course")]
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("Semester")]
        [Required]
        public int SemesterId { get; set; }

        
        [StringLength(3)]
        public string Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Semester Semester { get; set; }
        //added stuff 326
        

    }
}