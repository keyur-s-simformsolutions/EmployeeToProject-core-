using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject_core.Models
{
    public class EmployeeToProject
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
