using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class GroupFilter
    {
        public int GroupFilterId { get; set; }

        public int ToDoId { get; set; }

        public int GroupId { get; set; }

        public bool IsStudent { get; set; }

        public int AdvisorId { get; set; }

        public double GPAMin { get; set; }

        public double GPAMax { get; set; }

        public int CampusId { get; set; }

        public bool StatusEnrolled { get; set; }

        public bool StatusUnEnrolled { get; set; }

        public bool StatusGraduated { get; set; }

        public bool Petition { get; set; }


    }
}