using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject_core.ViewModel
{
    public class FilterSearch
    {
        public string Search { get; set; }
        public int? SortColunm { get; set; }
        public string SortOrder { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public string Sdate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public string Edate { get; set; }
        public int Pagenum { get; set; }
        public int Pagesize { get; set; }
    }
}
