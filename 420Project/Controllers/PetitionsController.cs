//Brooke Gorbandt
//Date: 3/26/17
//

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
    public class PetitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Petitions
        public ActionResult Index()
        {
            return View(db.Petition.ToList());
        }

        // GET: Petitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Petition petition = db.Petition.Find(id);
            if (petition == null)
            {
                return HttpNotFound();
            }
            return View(petition);
        }

        // GET: Petitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Petitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetitionID,Name")] Petition petition)
        {
            if (ModelState.IsValid)
            {
                db.Petition.Add(petition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(petition);
        }

        // GET: Petitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Petition petition = db.Petition.Find(id);
            if (petition == null)
            {
                return HttpNotFound();
            }
            return View(petition);
        }

        // POST: Petitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetitionID,Name")] Petition petition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petition);
        }

        // GET: Petitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Petition petition = db.Petition.Find(id);
            if (petition == null)
            {
                return HttpNotFound();
            }
            return View(petition);
        }

        // POST: Petitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Petition petition = db.Petition.Find(id);
            db.Petition.Remove(petition);
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
