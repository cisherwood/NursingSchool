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
    public class AdminCampusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCampus
        public ActionResult Index()
        {
            return View(db.Campus.ToList());
        }

        // GET: AdminCampus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: AdminCampus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCampus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampusID,CampusName,Address,City,State,ZipCode,PhoneNumber")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campus.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        // GET: AdminCampus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: AdminCampus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampusID,CampusName,Address,City,State,ZipCode,PhoneNumber")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campus);
        }

        // GET: AdminCampus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: AdminCampus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campus.Find(id);
            db.Campus.Remove(campus);
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
