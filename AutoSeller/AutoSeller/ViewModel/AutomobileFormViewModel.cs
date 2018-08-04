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

        public List<Detail> Details { get; set; }

        //        public IEnumerable<AutomobileDetail> AutomobileDetails { get; set; }
        public List<AutomobileDetail> AutomobileDetails { get; set; }


        public int? Id { get; set; }

        //the string is nullable by default, so no need of ?
        [Required]
        public string Name { get; set; }

        [Display(Name = "Country")]
        [Required]
        public int? CountryId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NuberInStock { get; set; }

        [Display(Name = "Make")]
        [Required]
        public int? AutomobileMakeId { get; set; }

        [Display(Name = "Model")]
        [Required]
        public int? AutomobileModelId { get; set; }

        public string Engine { get; set; }

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
            Name = automobile.Name;
            CountryId = automobile.CountryId;
            ReleaseDate = automobile.ReleaseDate;
            NuberInStock = automobile.NuberInStock;
            AutomobileMakeId = automobile.AutomobileMakeId;
            AutomobileModelId = automobile.AutomobileModelId;
            Engine = automobile.Engine;
            Color = automobile.Color;
            Doors = automobile.Doors;
            Transmission = automobile.Transmission;
            Miles = automobile.Miles;

        }
    }
}