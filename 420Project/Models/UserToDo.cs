using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class UserToDo
    {
        int id { get; set; }

        int ToDoId { get; set; }

        int UserId { get; set; }

        bool isComplete { get; set; }
    }

    
}