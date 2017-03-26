//Brooke Gorbandt
//Date: 2/24/17
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class StudentPetition
    {
        public int StudentPetitionID { get; set; }

        [StringLength(30)]
        [Required]
        public string Status { get; set; }

        [Display(Name = "Submit Date")]
        [Required]
        public DateTime? SubmitDate { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Student ID")]
        [Required]
        public int StudentID { get; set; }
    
        [ForeignKey("Petition")]
        [Display(Name = "Petition ID")]
        [Required]
        public int PetitionID { get; set; }






        public virtual Student Student { get; set; }

        public virtual Petition Petition { get; set; }

    }
}