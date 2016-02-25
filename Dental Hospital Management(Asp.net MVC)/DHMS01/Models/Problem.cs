using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DHMS01.Models
{
    public class Problem
    {
        [Key]
        public int ProblemId { get; set; }
        public string Problem1 { get; set; }
    }
}