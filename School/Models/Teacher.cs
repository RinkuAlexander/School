using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Teacher
    {
        public int id { get; set; }


        [Required]
        [Display(Name = "Teacher Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "Division")]
        public string Division { get; set; }

        
    }
}