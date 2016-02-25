using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DHMS01.Models;
using DHMS01.Models.Context;

namespace DHMS01.Controllers 
{
    public class ChiefComplainController : Controller
    {
        private DhmsContext db = new DhmsContext();



       

        // GET: /ChiefComplain/
        public ActionResult Index()
        {

            var complainDetails = db.ChiefComplains.Include(r => r.VComplains).Include(r => r.VAts);
            return View(complainDetails.ToList());
        }

        // GET: /ChiefComplain/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefComplain chiefcomplain = db.ChiefComplains.Find(id);
            if (chiefcomplain == null)
            {
                return HttpNotFound();
            }
            return View(chiefcomplain);
        }

        // GET: /ChiefComplain/Create
        public ActionResult Create()
        {
            ViewBag.ComplainId = new SelectList(db.Complains, "ComplainId", "ComplainName");
            ViewBag.AtId = new SelectList(db.Ats, "AtId", "AtName");
            return View();
        }

        // POST: /ChiefComplain/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ChiefComplainId,Complain,Duration,Reason,Comment,ComplainId,AtId")] ChiefComplain chiefcomplain)
        {
            if (ModelState.IsValid)
            {
                db.ChiefComplains.Add(chiefcomplain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.ComplainId = new SelectList(db.Complains, "ComplainId", "ComplainName",chiefcomplain.ComplainId);
            ViewBag.AtId = new SelectList(db.Ats, "AtId", "AtName",chiefcomplain.AtId);
            //ViewBag.Duration = new SelectList(db.ChiefComplains, "Duration", "Duration", chiefcomplain.Duration);
            //ViewBag.Reason = new SelectList(db.ChiefComplains, "Reason", "Reason", chiefcomplain.Reason);
            //ViewBag.Comment = new SelectList(db.ChiefComplains, "Comment", "Comment", chiefcomplain.Comment);

            //ViewBag.ChiefComplain = chiefcomplain;
            return View(chiefcomplain);
        }

       

        //public ActionResult FollowUp( ChiefComplain achiefcomplain)
        //{
            //if (ModelState.IsValid) 
            //{
             
            //    return RedirectToAction("Create");
            //}

           // ViewBag.ChiefComplain = chiefcomplain;
            //ViewBag.ComplainId = new SelectList(db.Complains, "ComplainId", "ComplainName", chiefcomplain.ComplainId);
            //ViewBag.AtId = new SelectList(db.Ats, "AtId", "AtName", chiefcomplain.AtId);
            //ViewBag.Duration = new SelectList(db.ChiefComplains, "Duration", "Duration", chiefcomplain.Duration);
            //ViewBag.Reason = new SelectList(db.ChiefComplains, "Reason", "Reason", chiefcomplain.Reason);
            //ViewBag.Comment = new SelectList(db.ChiefComplains, "Comment", "Comment", chiefcomplain.Comment);


        //    return View(achiefcomplain); 
        //}
        // GET: /ChiefComplain/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefComplain chiefcomplain = db.ChiefComplains.Find(id);
            if (chiefcomplain == null)
            {
                return HttpNotFound();
            }
            return View(chiefcomplain);
        }

        // POST: /ChiefComplain/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ChiefComplainId,Complain,Duration,Reason,Comment,ComplainId,AtId")] ChiefComplain chiefcomplain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiefcomplain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiefcomplain);
        }

        // GET: /ChiefComplain/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefComplain chiefcomplain = db.ChiefComplains.Find(id);
            if (chiefcomplain == null)
            {
                return HttpNotFound();
            }
            return View(chiefcomplain);
        }

        // POST: /ChiefComplain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiefComplain chiefcomplain = db.ChiefComplains.Find(id);
            db.ChiefComplains.Remove(chiefcomplain);
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
