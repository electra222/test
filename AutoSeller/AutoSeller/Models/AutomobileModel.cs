using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoSeller.Models
{
    public class AutomobileModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public AutomobileMake AutomobileMake { get; set; }

        [Display(Name = "Make")]
        public int AutomobileMakeId { get; set; }


    }
}