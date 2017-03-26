//Alexis Lentz
//2-24-17
//This model keeps track of the Campus locations
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class Campus
    {
        public int CampusID { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Campus Name")]
        [Required]
        public string CampusName { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        
    }
}