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
    public class AdminStudentPetitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminStudentPetitions
        public ActionResult Index()
        {
            var studentPetition = db.StudentPetition.Include(s => s.Petition).Include(s => s.Student);
            return View(studentPetition.ToList());
        }

        // GET: AdminStudentPetitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPetition studentPetition = db.StudentPetition.Find(id);
            if (studentPetition == null)
            {
                return HttpNotFound();
            }
            return View(studentPetition);
        }

        // GET: AdminStudentPetitions/Create
        public ActionResult Create()
        {
            ViewBag.PetitionID = new SelectList(db.Petition, "PetitionID", "Name");
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName");
            return View();
        }

        // POST: AdminStudentPetitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentPetitionID,Status,SubmitDate,StudentID,PetitionID")] StudentPetition studentPetition)
        {
            if (ModelState.IsValid)
            {
                db.StudentPetition.Add(studentPetition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetitionID = new SelectList(db.Petition, "PetitionID", "Name", studentPetition.PetitionID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName", studentPetition.StudentID);
            return View(studentPetition);
        }

        // GET: AdminStudentPetitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPetition studentPetition = db.StudentPetition.Find(id);
            if (studentPetition == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetitionID = new SelectList(db.Petition, "PetitionID", "Name", studentPetition.PetitionID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName", studentPetition.StudentID);
            return View(studentPetition);
        }

        // POST: AdminStudentPetitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentPetitionID,Status,SubmitDate,StudentID,PetitionID")] StudentPetition studentPetition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPetition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetitionID = new SelectList(db.Petition, "PetitionID", "Name", studentPetition.PetitionID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName", studentPetition.StudentID);
            return View(studentPetition);
        }

        // GET: AdminStudentPetitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPetition studentPetition = db.StudentPetition.Find(id);
            if (studentPetition == null)
            {
                return HttpNotFound();
            }
            return View(studentPetition);
        }

        // POST: AdminStudentPetitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentPetition studentPetition = db.StudentPetition.Find(id);
            db.StudentPetition.Remove(studentPetition);
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
