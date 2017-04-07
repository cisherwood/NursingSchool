using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class GroupFilterCompliance
    {
        public int GroupFilterComplianceId { get; set; }

        [ForeignKey("GroupFilter")]
        public int GroupFilterId { get; set; }

        [ForeignKey("Compliance")]
        public int ComplianceId { get; set; }

        public bool CheckCompliance { get; set; }

        public bool IsCompliant { get; set; }

        
        
        public virtual GroupFilter GroupFilter { get; set; }

    }
}