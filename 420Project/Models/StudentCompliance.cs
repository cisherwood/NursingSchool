using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class StudentCompliance
    {
        public DateTime ExpirationDate { get; set; }
        public DateTime SubmissionDate { get; set; }

        public virtual Compliance ComplianceId { get; set; }
        public virtual Student StudentId { get; set; }
    }
}