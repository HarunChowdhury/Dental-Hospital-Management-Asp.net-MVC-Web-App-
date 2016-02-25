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
    public class AppTypeController : Controller
    {
        private DhmsContext db = new DhmsContext();

        // GET: /AppType/
        public ActionResult Index()
        {
            return View(db.AppTypes.ToList());
        }

        // GET: /AppType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppType apptype = db.AppTypes.Find(id);
            if (apptype == null)
            {
                return HttpNotFound();
            }
            return View(apptype);
        }

        // GET: /AppType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AppType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AppId,AppType1")] AppType apptype)
        {
            if (ModelState.IsValid)
            {
                db.AppTypes.Add(apptype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apptype);
        }

        // GET: /AppType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppType apptype = db.AppTypes.Find(id);
            if (apptype == null)
            {
                return HttpNotFound();
            }
            return View(apptype);
        }

        // POST: /AppType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AppId,AppType1")] AppType apptype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apptype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apptype);
        }

        // GET: /AppType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppType apptype = db.AppTypes.Find(id);
            if (apptype == null)
            {
                return HttpNotFound();
            }
            return View(apptype);
        }

        // POST: /AppType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppType apptype = db.AppTypes.Find(id);
            db.AppTypes.Remove(apptype);
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
