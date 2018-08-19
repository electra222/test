using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoSeller.ViewModel
{
    public class AutomobileFormViewModel
    {
        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<AutomobileMake> AutomobileMakes { get; set; }

        public IEnumerable<AutomobileModel> AutomobileModels { get; set; }

        public IEnumerable<Engine> Engines { get; set; }


        public List<Detail> Details { get; set; }

        public List<AutomobileDetail> AutomobileDetails { get; set; }

        public int? Id { get; set; }

        //the string is nullable by default, so no need of ?

        [Display(Name = "Country")]
        [Required]
        public int? CountryId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Make")]
        [Required]
        public int? AutomobileMakeId { get; set; }

        [Display(Name = "Model")]
        [Required]
        public int? AutomobileModelId { get; set; }

        [Display(Name = "Engine")]
        [Required]
        public int? EngineId { get; set; }

        public string Color { get; set; }

        [Range(1, 5)]
        public byte? Doors { get; set; }

        public string Transmission { get; set; }

        public float? Miles { get; set; }

        public AutomobileFormViewModel()
        {
            Id = 0;
        }

        public AutomobileFormViewModel(Automobile automobile)
        {
            Id = automobile.Id;
            CountryId = automobile.CountryId;
            ReleaseDate = automobile.ReleaseDate;
            AutomobileMakeId = automobile.AutomobileMakeId;
            AutomobileModelId = automobile.AutomobileModelId;
            EngineId = automobile.EngineId;
            Color = automobile.Color;
            Doors = automobile.Doors;
            Transmission = automobile.Transmission;
            Miles = automobile.Miles;

        }
    }
}