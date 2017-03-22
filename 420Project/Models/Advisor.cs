using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace _420Project.Models
{
    public class Advisor
    {
        public int AdvisorId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string TitleDescription { get; set; }

        [StringLength(50)]
        public string Office { get; set; }
        public int UserId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

    }
}