using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DHMS01.Models.Context
{
    public class DhmsContext:DbContext
    {
        public DbSet<Appointments> Appointment { set; get; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<AppType> AppTypes{ get; set; } 
        public DbSet<AppointmentCreate> AppointmentCreates { get; set; }
        public DbSet<PatientPersonalInfo> PatientPersonalInfos { get; set; }
        public DbSet<ChiefComplain> ChiefComplains { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<At> Ats { get; set; }


    }
}