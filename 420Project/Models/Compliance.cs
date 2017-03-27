//Michael Marshall
//2/24/2017
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _420Project.Models
{
    public class Compliance
    {
        //General "Primary Key" Id Property.
        public int Id { get; set; }

        //Property that will hold the Compliance's name.
        //Currently set at a Minimum length of 3 and Maximum length of 50.

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        //Property that will hold the actual file submitted.
        public File File { get; set; }

        //Navigation Properties
        public virtual ICollection<StudentCompliance> StudentCompliances { get; set; }
    
    }
}