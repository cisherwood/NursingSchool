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
    public class AdminEnrollmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminEnrollments
        public ActionResult Index()
        {
            var enrollment = db.Enrollment.Include(e => e.Course).Include(e => e.Semester).Include(e => e.Student).Include(e => e.StudentProgram);
            return View(enrollment.ToList());
        }

        // GET: AdminEnrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: AdminEnrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number");
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season");
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId");
            ViewBag.StudentProgramId = new SelectList(db.StudentProgram, "StudentProgramId", "Status");
            return View();
        }

        // POST: AdminEnrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,StudentId,CourseId,SemesterId,StudentProgramId,Grade,QPts,IsTransferCredit")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollment.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number", enrollment.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season", enrollment.SemesterId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId", enrollment.StudentId);
            ViewBag.StudentProgramId = new SelectList(db.StudentProgram, "StudentProgramId", "Status", enrollment.StudentProgramId);
            return View(enrollment);
        }

        // GET: AdminEnrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number", enrollment.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season", enrollment.SemesterId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId", enrollment.StudentId);
            ViewBag.StudentProgramId = new SelectList(db.StudentProgram, "StudentProgramId", "Status", enrollment.StudentProgramId);
            return View(enrollment);
        }

        // POST: AdminEnrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,StudentId,CourseId,SemesterId,StudentProgramId,Grade,QPts,IsTransferCredit")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number", enrollment.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season", enrollment.SemesterId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId", enrollment.StudentId);
            ViewBag.StudentProgramId = new SelectList(db.StudentProgram, "StudentProgramId", "Status", enrollment.StudentProgramId);
            return View(enrollment);
        }

        // GET: AdminEnrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: AdminEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollment.Find(id);
            db.Enrollment.Remove(enrollment);
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
