using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Student
    {
        public int id { get; set; }
        

        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "Division")]
        public string Division { get; set; }

        [Required]
        [Display(Name = "Educational Status")]
        public string Status { get; set; }
    }
}