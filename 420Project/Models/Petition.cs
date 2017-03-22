using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class Petition
    {
        public int PetitionID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        
    }
}