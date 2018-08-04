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

        public AutomobileMake AutomobileMake { get; set; }

        [Display(Name = "Make")]
        public int AutomobileMakeId { get; set; }

        [Display(Name = "Model")]
        public AutomobileModel AutomobileModel { get; set; }

        public int AutomobileModelId { get; set; }

        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Import Date")]
        public DateTime DateImported { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NuberInStock { get; set; }

        public string Engine { get; set; }

        public string Color { get; set; }

        [Range(1, 5)]
        public byte Doors { get; set; }

        public string Transmission { get; set; }

        public float Miles { get; set; }

    }
}