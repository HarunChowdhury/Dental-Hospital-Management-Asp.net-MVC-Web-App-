using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DHMS01.Models.Enum
{
    public class AllEnum
    {
        public enum Sex
        {
            [Display(Name = "Male")]
            Male = 1,
            [Display(Name = "Female")]
            Female = 2 
        }

        

        public enum MaritalStatus
        {
            [Display(Name = "Single")]
            Single = 3,
            [Display(Name = "Married")]
            Married = 4,
             [Display(Name = "Divorced")]
            Divorced = 5,
            [Display(Name = "Separated")]
             Separated = 6   
        }

       
        
    }
}