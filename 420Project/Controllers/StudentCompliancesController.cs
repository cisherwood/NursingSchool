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
    public class StudentCompliancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentCompliances
        public ActionResult Index()
        {
            var studentCompliance = db.StudentCompliance.Include(s => s.Compliance).Include(s => s.Student);
            return View(studentCompliance.ToList());
        }

        // GET: StudentCompliances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCompliance studentCompliance = db.StudentCompliance.Find(id);
            if (studentCompliance == null)
            {
                return HttpNotFound();
            }
            return View(studentCompliance);
        }

        // GET: StudentCompliances/Create
        public ActionResult Create()
        {
            ViewBag.ComplianceId = new SelectList(db.Compliance, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName");
            return View();
        }

        // POST: StudentCompliances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCId,ExpirationDate,SubmissionDate,ComplianceId,StudentId")] StudentCompliance studentCompliance)
        {
            if (ModelState.IsValid)
            {
                db.StudentCompliance.Add(studentCompliance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplianceId = new SelectList(db.Compliance, "Id", "Name", studentCompliance.ComplianceId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName", studentCompliance.StudentId);
            return View(studentCompliance);
        }

        // GET: StudentCompliances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCompliance studentCompliance = db.StudentCompliance.Find(id);
            if (studentCompliance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplianceId = new SelectList(db.Compliance, "Id", "Name", studentCompliance.ComplianceId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName", studentCompliance.StudentId);
            return View(studentCompliance);
        }

        // POST: StudentCompliances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCId,ExpirationDate,SubmissionDate,ComplianceId,StudentId")] StudentCompliance studentCompliance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCompliance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplianceId = new SelectList(db.Compliance, "Id", "Name", studentCompliance.ComplianceId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName", studentCompliance.StudentId);
            return View(studentCompliance);
        }

        // GET: StudentCompliances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCompliance studentCompliance = db.StudentCompliance.Find(id);
            if (studentCompliance == null)
            {
                return HttpNotFound();
            }
            return View(studentCompliance);
        }

        // POST: StudentCompliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCompliance studentCompliance = db.StudentCompliance.Find(id);
            db.StudentCompliance.Remove(studentCompliance);
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
