using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DHMS01.Models
{
    public class Time
    {
        [Key]
        public int TimeId { get; set; }
        public string Time1 { get; set; } 
    }
}