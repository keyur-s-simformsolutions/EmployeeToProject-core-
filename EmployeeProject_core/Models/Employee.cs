using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject_core.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
