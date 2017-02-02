using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Models
{
    public class Program
    {
        public int ProgramId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentProgram> StudentPrograms { get; set; }
        public virtual ICollection<ProgramCourse> ProgramCourses { get; set; }

    }
}