using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject_core.ViewModel
{
    public class EmployeeToProjectViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string FullName { get; set; }
        public string ProjectName { get; set; }
        public decimal Cost { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
    }
}
