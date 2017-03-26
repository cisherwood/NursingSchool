//Alexis Lentz
//2-24-17
//This model keeps track of the ToDos
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

        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
      
    }
}