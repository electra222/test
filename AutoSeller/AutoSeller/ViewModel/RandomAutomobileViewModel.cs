 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;

namespace AutoSeller.ViewModel
{
    public class RandomAutomobileViewModel
    {
        public Automobile Automobile { get; set; }
        public List<Customer> Customers { get; set; }

    }
}