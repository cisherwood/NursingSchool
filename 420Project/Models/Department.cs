using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace _420Project.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [StringLength(100)]
        public string Name  { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}