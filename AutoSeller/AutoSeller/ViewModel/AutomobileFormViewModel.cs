using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;

namespace AutoSeller.ViewModel
{
    public class AutomobileFormViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public Automobile Automobile { get; set; }
    }
}