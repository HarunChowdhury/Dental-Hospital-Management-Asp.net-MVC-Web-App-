using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DHMS01.Models
{
    public class AppType
    {
        [Key]
        public int AppId { get; set; }
        public string AppType1 { get; set; }
    }
}