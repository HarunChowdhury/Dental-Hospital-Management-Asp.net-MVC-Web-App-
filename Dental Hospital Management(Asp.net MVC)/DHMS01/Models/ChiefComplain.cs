using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DHMS01.Models
{
    public class ChiefComplain
    {
        public int ChiefComplainId { get; set; }
        public string  Complain{ get; set; }
        public int  Duration { get; set; }
        public string  Reason{ get; set; }
        public string  Comment { get; set; }
      
        public int ComplainId { get; set; }
        public int AtId { get; set; } 
        public virtual Complain  VComplains{ get; set; }
        public virtual At VAts{ get; set; }

      

    }
}