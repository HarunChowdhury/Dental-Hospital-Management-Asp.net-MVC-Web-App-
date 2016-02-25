using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using DHMS01.Models;
using DHMS01.Models.Context;

namespace DHMS01.Controllers
{
    public class PatientPersonalInfoController : Controller
    {
        private DhmsContext db = new DhmsContext();




      

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="option"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// Search By Name/Phone/Address
        public ActionResult PatientSearchForm(string option, string search)   
        
        {  
  
                  //if a user choose the radio button option as Subject  
             if (option == "Name") 
             {  
                
               // return View(db.PatientPersonalInfos.Where(m=>m.Name == search || search == null).ToList());

                return View(db.PatientPersonalInfos.Where(m => m.Name.StartsWith(search) || search == null).ToList());
             } 

             else if (option == "MobilePhone")
                   {  
                  // return View(db.PatientPersonalInfos.Where(m=>m.MobilePhone == search || search == null).ToList());

                       return View(db.PatientPersonalInfos.Where(m => m.MobilePhone.StartsWith(search) || search == null).ToList());
                   }
             else if (option == "PresentAddress")
             {
                // return View(db.PatientPersonalInfos.Where(m => m.PresentAddress == search || search == null).ToList());
                 return View(db.PatientPersonalInfos.Where( m=>m.PresentAddress.StartsWith(search) || search == null).ToList());  
             }
             else
             {
                 return View(db.PatientPersonalInfos.ToList());
             }

                         
        }  


      
       
        // GET: /PatientPersonalInfo/
        public ActionResult Index()
        {
            return View(db.PatientPersonalInfos.ToList());
        }

        // GET: /PatientPersonalInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientPersonalInfo patientpersonalinfo = db.PatientPersonalInfos.Find(id);
            if (patientpersonalinfo == null)
            {
                return HttpNotFound();
            }
            return View(patientpersonalinfo);
        }

        // GET: /PatientPersonalInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PatientPersonalInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PatientPersonalInfoId,EntryDate,PatientId,Name,Sex,Dob,PatientAge,FatherName,MotherName,MaritalStatus,SpouseName,PresentAddress,MobilePhone,Email,Occupation,Designation,ReferredBy")] PatientPersonalInfo patientpersonalinfo)
        {
            if (ModelState.IsValid)
            {
                db.PatientPersonalInfos.Add(patientpersonalinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientpersonalinfo);
        }

        // GET: /PatientPersonalInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientPersonalInfo patientpersonalinfo = db.PatientPersonalInfos.Find(id);
            if (patientpersonalinfo == null)
            {
                return HttpNotFound();
            }
            return View(patientpersonalinfo);
        }

        // POST: /PatientPersonalInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PatientPersonalInfoId,EntryDate,PatientId,Name,Sex,Dob,PatientAge,FatherName,MotherName,MaritalStatus,SpouseName,PresentAddress,MobilePhone,Email,Occupation,Designation,ReferredBy")] PatientPersonalInfo patientpersonalinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientpersonalinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientpersonalinfo);
        }

        // GET: /PatientPersonalInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientPersonalInfo patientpersonalinfo = db.PatientPersonalInfos.Find(id);
            if (patientpersonalinfo == null)
            {
                return HttpNotFound();
            }
            return View(patientpersonalinfo);
        }

        // POST: /PatientPersonalInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientPersonalInfo patientpersonalinfo = db.PatientPersonalInfos.Find(id);
            db.PatientPersonalInfos.Remove(patientpersonalinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
