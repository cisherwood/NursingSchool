using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class StudentPetition
    {
        public int StudentPetitionID { get; set; }
        public string Status { get; set; }
        public DateTime SubmitDate { get; set; }

        public int StudentID { get; set; }
        public int PetitionID { get; set; }
    }
}