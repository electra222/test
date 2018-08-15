using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSeller.ViewModel
{
    public class ImagesFormViewModel
    {
        public int AutomobileId { get; set; }

        public IEnumerable<FileModel> FileModels { get; set; }

        public bool? Success { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

    }
}