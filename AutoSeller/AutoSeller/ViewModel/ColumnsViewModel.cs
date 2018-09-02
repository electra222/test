using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;


namespace AutoSeller.ViewModel
{
    public class ColumnsViewModel
    {
        public IEnumerable<Automobile> Automobiles { get; set; }
    }
}