using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _420Project.Models;

namespace _420Project.Models
{
    public class StudentCompliance
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime SubmissionDate { get; set; }

        public int ComplianceId { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Compliance Compliance { get; set; }
    }
}