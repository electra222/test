using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoSeller.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}