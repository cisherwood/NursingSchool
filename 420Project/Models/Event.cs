using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(150)]
        public string Location { get; set; }
        public bool IsRecruitmentEvent { get; set; }
        public DateTime? Date { get; set;}

    }
}