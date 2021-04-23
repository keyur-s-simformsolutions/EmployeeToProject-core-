using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject_core.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
