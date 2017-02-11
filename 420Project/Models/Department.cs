using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name  { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}