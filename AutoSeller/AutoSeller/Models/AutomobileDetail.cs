using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoSeller.Models
{
    public class AutomobileDetail
    {
        public int Id { get; set; }
        public Automobile Automobile { get; set; }
        public int? AutomobileId { get; set; }
        public Detail Detail { get; set; }
        public int? DetailId { get; set; }
        public string DetailValue { get; set; }
    }
}