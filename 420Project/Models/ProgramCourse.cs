//Brentan Hudson
//2/24/17
//bridge between LD BSN, and courses required for that program

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models

{
    public class ProgramCourse
    {
        public int ProgramCourseId { get; set; }

        [ForeignKey("Program")]
        [Display(name = "Program")]
        [Required]
        public int ProgramId { get; set; }

        [Display(Name = "Course ID")]
        [Required]
        public int CourseId { get; set; }
        [Display(Name = "Semester")]
        [Required]
        public int SemesterNumber { get; set; }

        public virtual Course Course { get; set; }
        public virtual Program Program { get; set; }
        //326

        

    }
}