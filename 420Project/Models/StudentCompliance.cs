using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _420Project.Models;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models

{
    //Bridge table for Student and Compliance. Model links them together and displays all the compliances a particular student has.
    public class StudentCompliance
    {
        //General "Primary Key" Id property.
        public int Id { get; set; }

        //Properties to hold the dates that the compliance is submitted and expires.
        public DateTime ExpirationDate { get; set; }
        public DateTime SubmissionDate { get; set; }

        //Foreign Keys for Compliance and Student.
        public int ComplianceId { get; set; }
        public int StudentId { get; set; }

        //References to the student and compliance models.
        public virtual Student Student { get; set; }
        public virtual Compliance Compliance { get; set; }
    }
}