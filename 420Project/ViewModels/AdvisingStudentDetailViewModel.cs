using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _420Project.Models;

namespace _420Project.ViewModels
{
    public class AdvisingStudentDetailViewModel
    {
        Student Student { get; set; }

        List<ToDo> ToDos { get; set; }

        List<Event> Events { get; set; }
    }
}