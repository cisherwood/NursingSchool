using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _420Project.Models;

namespace _420Project.Controllers
{
    public class AdminCompliancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCompliances
        public ActionResult Index()
        {
            return View(db.Compliance.ToList());
        }

        // GET: AdminCompliances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compliance compliance = db.Compliance.Find(id);
            if (compliance == null)
            {
                return HttpNotFound();
            }
            return View(compliance);
        }

        // GET: AdminCompliances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCompliances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Compliance compliance)
        {
            if (ModelState.IsValid)
            {
                db.Compliance.Add(compliance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compliance);
        }

        // GET: AdminCompliances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compliance compliance = db.Compliance.Find(id);
            if (compliance == null)
            {
                return HttpNotFound();
            }
            return View(compliance);
        }

        // POST: AdminCompliances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Compliance compliance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compliance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compliance);
        }

        // GET: AdminCompliances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compliance compliance = db.Compliance.Find(id);
            if (compliance == null)
            {
                return HttpNotFound();
            }
            return View(compliance);
        }

        // POST: AdminCompliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compliance compliance = db.Compliance.Find(id);
            db.Compliance.Remove(compliance);
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
