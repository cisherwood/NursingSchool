using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _420Project.Models;

namespace _420Project.ViewModels
{
    public class AdvisingStudentDetailViewModel
    {
        public Student Student { get; set; }

        public List<ToDo> ToDos { get; set; }

        public List<Event> Events { get; set; }
    }
}