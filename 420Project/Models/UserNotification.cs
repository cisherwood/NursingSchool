using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class UserNotification
    {
        [Key]
        public int UserNotificationId { get; set; }

        public int NotificationId { get; set; }

        public int UserId { get; set; }

        public bool isComplete { get; set; }
    }
}