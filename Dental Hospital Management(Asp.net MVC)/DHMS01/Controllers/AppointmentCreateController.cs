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
    public class AppointmentCreateController : Controller
    {
        private DhmsContext db = new DhmsContext();

        // GET: /AppointmentCreate/
        public ActionResult Index()
        {
            var appcreates =
                db.AppointmentCreates.Include(c => c.VTime).Include(c => c.VAppType).Include(c => c.VProblem);

            return View(appcreates.ToList());
        }

        // GET: /AppointmentCreate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentCreate appointmentcreate = db.AppointmentCreates.Find(id);
            if (appointmentcreate == null)
            {
                return HttpNotFound();
            }
            return View(appointmentcreate);
        }

        // GET: /AppointmentCreate/Create
        public ActionResult Create()
        {
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Time1");
            ViewBag.AppId = new SelectList(db.AppTypes, "AppId", "AppType1");

            ViewBag.ProblemId = new SelectList(db.Problems, "ProblemId", "Problem1");
            return View();
        }

        // POST: /AppointmentCreate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AppointmentCreateId,TimeId,Date,Serial,PatientName,PhonNum,AppId,ProblemId")] AppointmentCreate appointmentcreate)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentCreates.Add(appointmentcreate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Time1",db.Times);
            ViewBag.AppId = new SelectList(db.AppTypes, "AppId", "AppType1",db.AppTypes);

            ViewBag.ProblemId = new SelectList(db.Problems, "ProblemId", "Problem1",db.Problems);

            return View(appointmentcreate);
        }

        // GET: /AppointmentCreate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentCreate appointmentcreate = db.AppointmentCreates.Find(id);
            if (appointmentcreate == null)
            {
                return HttpNotFound();
            }


            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Time1", db.Times);
            ViewBag.AppId = new SelectList(db.AppTypes, "AppId", "AppType1", db.AppTypes);

            ViewBag.ProblemId = new SelectList(db.Problems, "ProblemId", "Problem1", db.Problems);
            return View(appointmentcreate);
        }

        // POST: /AppointmentCreate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AppointmentCreateId,TimeId,Date,Serial,PatientName,PhonNum,AppId,ProblemId")] AppointmentCreate appointmentcreate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentcreate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Time1", db.Times);
            ViewBag.AppId = new SelectList(db.AppTypes, "AppId", "AppType1", db.AppTypes);

            ViewBag.ProblemId = new SelectList(db.Problems, "ProblemId", "Problem1", db.Problems);
            return View(appointmentcreate);
        }

        // GET: /AppointmentCreate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentCreate appointmentcreate = db.AppointmentCreates.Find(id);
            if (appointmentcreate == null)
            {
                return HttpNotFound();
            }
            return View(appointmentcreate);
        }

        // POST: /AppointmentCreate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentCreate appointmentcreate = db.AppointmentCreates.Find(id);
            db.AppointmentCreates.Remove(appointmentcreate);
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
