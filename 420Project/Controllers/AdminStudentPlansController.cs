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
    public class AdminStudentPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminStudentPlans
        public ActionResult Index()
        {
            var studentPlans = db.StudentPlans.Include(s => s.Course).Include(s => s.Program).Include(s => s.Semester).Include(s => s.Student);
            return View(studentPlans.ToList());
        }

        // GET: AdminStudentPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPlan studentPlan = db.StudentPlans.Find(id);
            if (studentPlan == null)
            {
                return HttpNotFound();
            }
            return View(studentPlan);
        }

        // GET: AdminStudentPlans/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number");
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name");
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season");
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId");
            return View();
        }

        // POST: AdminStudentPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentPlanId,EnrollmentId,StudentId,CourseId,SemesterId,ProgramId")] StudentPlan studentPlan)
        {
            if (ModelState.IsValid)
            {
                db.StudentPlans.Add(studentPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number", studentPlan.CourseId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentPlan.ProgramId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season", studentPlan.SemesterId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId", studentPlan.StudentId);
            return View(studentPlan);
        }

        // GET: AdminStudentPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPlan studentPlan = db.StudentPlans.Find(id);
            if (studentPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number", studentPlan.CourseId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentPlan.ProgramId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season", studentPlan.SemesterId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId", studentPlan.StudentId);
            return View(studentPlan);
        }

        // POST: AdminStudentPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentPlanId,EnrollmentId,StudentId,CourseId,SemesterId,ProgramId")] StudentPlan studentPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "Number", studentPlan.CourseId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentPlan.ProgramId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "Season", studentPlan.SemesterId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "UserId", studentPlan.StudentId);
            return View(studentPlan);
        }

        // GET: AdminStudentPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPlan studentPlan = db.StudentPlans.Find(id);
            if (studentPlan == null)
            {
                return HttpNotFound();
            }
            return View(studentPlan);
        }

        // POST: AdminStudentPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentPlan studentPlan = db.StudentPlans.Find(id);
            db.StudentPlans.Remove(studentPlan);
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
