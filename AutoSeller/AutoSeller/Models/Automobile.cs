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

        public Country Country { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Import Date")]
        public DateTime DateImported { get; set; }

        public Engine Engine { get; set; }

        [Display(Name = "Engine")]
        public int? EngineId { get; set; }

        public string Color { get; set; }

        [Range(2, 6)]
        public byte Doors { get; set; }

        public string Transmission { get; set; }

        public float Miles { get; set; }

        public virtual ICollection<FileModel> FileModels { get; set; }

        public Status Status { get; set; }
        public int StatusId { get; set; }

        public int? Counter { get; set; }

    }
}