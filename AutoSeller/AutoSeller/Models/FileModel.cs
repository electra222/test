using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSeller.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public Automobile Automobile { get; set; }
        public int? AutomobileId { get; set; }

    }
}