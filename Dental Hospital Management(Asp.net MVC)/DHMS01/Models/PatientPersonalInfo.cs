using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DHMS01.Models.Enum;

namespace DHMS01.Models
{
    public class PatientPersonalInfo
    {
        public int PatientPersonalInfoId { get; set; }
        public DateTime EntryDate { get; set; }
        public string  PatientId { get; set; }
        //public ImageButton Image { get; set; } 
        public string  Name { get; set; }

        public AllEnum.Sex Sex { get; set; } 

        public DateTime Dob { get; set; }
        public int PatientAge  { get; set; } 
        public string FatherName { get; set; }
        public string  MotherName { get; set; }

        public AllEnum.MaritalStatus  MaritalStatus { get; set; } 

        public string  SpouseName { get; set; }
        public string  PresentAddress { get; set; }
        public string  MobilePhone { get; set; }
        public string Email { get; set; }
        public string  Occupation { get; set; }
        public string  Designation { get; set; }
        public string  ReferredBy { get; set; }

     



    }
}