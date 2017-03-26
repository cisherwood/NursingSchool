//Brentan Hudson
//2/24/17
//Program model identifying what specific program the student is in
//no foreign key

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Program
    {
        public int ProgramId { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<StudentProgram> StudentPrograms { get; set; }
        public virtual ICollection<ProgramCourse> ProgramCourses { get; set; }

        



    }
}