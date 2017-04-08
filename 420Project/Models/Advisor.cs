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
        public string Office { get; set; }

        public string UserId { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}