//Joey Kunkel
//2/24/17
//Keeps track of advisors. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420Project.Models
{

    public class Advisor
    {
        
        public int AdvisorId { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string TitleDescription { get; set; }

        [StringLength(50)]
        public string Office { get; set; }

       
        public int UserId { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

    }
}