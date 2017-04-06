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
    public class AdminStudentProgramsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminStudentPrograms
        public ActionResult Index()
        {
            var studentProgram = db.StudentProgram.Include(s => s.Program).Include(s => s.Student);
            return View(studentProgram.ToList());
        }

        // GET: AdminStudentPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            if (studentProgram == null)
            {
                return HttpNotFound();
            }
            return View(studentProgram);
        }

        // GET: AdminStudentPrograms/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name");
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName");
            return View();
        }

        // POST: AdminStudentPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentProgramId,StudentId,ProgramId,Status")] StudentProgram studentProgram)
        {
            if (ModelState.IsValid)
            {
                db.StudentProgram.Add(studentProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentProgram.ProgramId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName", studentProgram.StudentId);
            return View(studentProgram);
        }

        // GET: AdminStudentPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            if (studentProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentProgram.ProgramId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName", studentProgram.StudentId);
            return View(studentProgram);
        }

        // POST: AdminStudentPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentProgramId,StudentId,ProgramId,Status")] StudentProgram studentProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentProgram.ProgramId);
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "FirstName", studentProgram.StudentId);
            return View(studentProgram);
        }

        // GET: AdminStudentPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            if (studentProgram == null)
            {
                return HttpNotFound();
            }
            return View(studentProgram);
        }

        // POST: AdminStudentPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            db.StudentProgram.Remove(studentProgram);
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
