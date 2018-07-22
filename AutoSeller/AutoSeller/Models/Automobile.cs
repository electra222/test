using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoSeller.Models
{
    public class Automobile
    {

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        [Display (Name = "Country")]
        public int CountryId { get; set; }

        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Import Date")]
        public DateTime DateImported { get; set;}

        [Display (Name = "Number in Stock")]
        public byte NuberInStock { get; set; }

    }
}