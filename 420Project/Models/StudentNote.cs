using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class StudentNote
    {
        public int StudentNoteId { get; set; }

        public int StudentId { get; set; }

        public int AdvisorId { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}