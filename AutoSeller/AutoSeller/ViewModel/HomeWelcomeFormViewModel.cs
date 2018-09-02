using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoSeller.ViewModel
{
    public class HomeWelcomeFormViewModel
    {
        public static string ImagePath = "~/Content/Images/Logo_TV_2015.png";

        public static string WelcomeText = "Welcome!";

        [Required]
        [Display(Name = "Welcome text:")]
        public string DynamicText { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File:")]
        public HttpPostedFileBase file { get; set; }
    }
}