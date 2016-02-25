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
    public class AtController : Controller
    {
        private DhmsContext db = new DhmsContext();

        // GET: /At/
        public ActionResult Index()
        {
            return View(db.Ats.ToList());
        }

        // GET: /At/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            At at = db.Ats.Find(id);
            if (at == null)
            {
                return HttpNotFound();
            }
            return View(at);
        }

        // GET: /At/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /At/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AtId,AtName")] At at)
        {
            if (ModelState.IsValid)
            {
                db.Ats.Add(at);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(at);
        }

        // GET: /At/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            At at = db.Ats.Find(id);
            if (at == null)
            {
                return HttpNotFound();
            }
            return View(at);
        }

        // POST: /At/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AtId,AtName")] At at)
        {
            if (ModelState.IsValid)
            {
                db.Entry(at).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(at);
        }

        // GET: /At/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            At at = db.Ats.Find(id);
            if (at == null)
            {
                return HttpNotFound();
            }
            return View(at);
        }

        // POST: /At/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            At at = db.Ats.Find(id);
            db.Ats.Remove(at);
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
