using _420Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _420Project.ViewModels
{
    public class _GroupFilterCompliancesViewModel
    {
        public GroupFilter GroupFilters { get; set; }

        public List<GroupFilterCompliance> complianceFilters { get; set; }

        public List<GroupFilterProgram> programFilters { get; set; }
    }
}