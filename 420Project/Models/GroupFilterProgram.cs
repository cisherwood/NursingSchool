using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _420Project.Models
{
    public class GroupFilterProgram
    {

        public int GroupFilterProgramId { get; set; }

        [ForeignKey("GroupFilter")]
        public int GroupFilterId { get; set; }

        [ForeignKey("Program")]
        public int ProgramId { get; set; }
    }
}