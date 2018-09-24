using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;

namespace AutoSeller.ViewModel
{
    public class HomeFormViewModel
    {
        public HomeWelcomeFormViewModel HomeWelcomeFormViewModel { get; set; }

        public IEnumerable<IEnumerable<Automobile>> AutomobileList { get; set; }
       // public Automobile Automobile { get; set; }
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public IEnumerable<AutomobileMake> AutomobileMakeList { get; set; }
        public IEnumerable<AutomobileModel> AutomobileModelList { get; set; }
        public IEnumerable<FileModel> FileModel { get; set; }
        public int? Year { get; set; }

    }
}