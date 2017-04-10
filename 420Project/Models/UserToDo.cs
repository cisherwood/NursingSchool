using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class UserToDo
    {
        [Key]
        public int UserToDoId { get; set; }

        public int ToDoId { get; set; }

        public string UserId { get; set; }

        public bool isComplete { get; set; }

        public virtual ToDo ToDo { get; set; }
    }

    
}