using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoSeller.ViewModel
{
    public class AboutViewForm
    {
        public static string AboutText = "Here you will find information for us and our company!";

        [Required]
        [Display(Name = "About text:")]
        public string DynamicText { get; set; }
    }
}