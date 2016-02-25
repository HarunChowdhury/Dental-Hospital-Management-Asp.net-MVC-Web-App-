using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DHMS01.Models
{
    public class AppointmentCreate
    {
        public int AppointmentCreateId { get; set; }

         [Display(Name = "When")]
        public int TimeId { get; set; }

        public DateTime Date { get; set; }
        public string Serial { get; set; }

         [Display(Name = " Patient Name")]
        public string PatientName { get; set; }

          [Display(Name = "Phone No")]
        public string PhonNum { get; set; }

        [Display(Name = "App Type")]
        public int AppId { get; set; }

        public int ProblemId { get; set; }


        public virtual Time VTime { get; set; }
        public virtual AppType VAppType { get; set; }
        public virtual Problem VProblem { get; set; }


    }
}