using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public string Name { get; set; }
    }
}