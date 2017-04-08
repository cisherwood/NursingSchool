//Joey Kunkel
//2/24/17
//Track student information. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string UserId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string MiddleName { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public string Email { get; set; }

        [StringLength(15, MinimumLength = 1)]
        public string PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Address { get; set; }

        [ForeignKey("Advisor")]
        public int AdvisorId { get; set; }

        [StringLength(50)]
        public string Year { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DOB { get; set; }

        public bool NeedCompliance { get; set; }// If student is LD == false, if UD or grade == true

        [ForeignKey("Campus")]
        public int CampusId { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<StudentCompliance> Compliances { get; set; }
        public virtual Campus Campus { get; set; }
        public virtual Advisor Advisor { get; set; }
        public virtual ICollection<StudentProgram> StudentProgram { get; set; }




    }
}