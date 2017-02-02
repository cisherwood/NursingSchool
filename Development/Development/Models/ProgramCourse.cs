using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Development.Models

{
    public class ProgramCourse
    {
        public int ProgramCourseId { get; set; }
        public int ProgramId { get; set; }
        public int CourseId { get; set; }
        public int Semester { get; set; }

        public virtual Course Course { get; set; }
        public virtual Program Program { get; set; }


    }
}