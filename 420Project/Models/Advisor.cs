using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Advisor
    {
        public int AdvisorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleDescription { get; set; }
        public string Office { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

    }
}