using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class ToDo
    {
        public int ToDoID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int GroupID { get; set; }
    }
}