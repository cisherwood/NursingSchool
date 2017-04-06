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
    public class AdminGroupFiltersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminGroupFilters
        public ActionResult Index()
        {
            return View(db.GroupFilters.ToList());
        }

        // GET: AdminGroupFilters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupFilter groupFilter = db.GroupFilters.Find(id);
            if (groupFilter == null)
            {
                return HttpNotFound();
            }
            return View(groupFilter);
        }

        // GET: AdminGroupFilters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminGroupFilters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupFilterId,ToDoId")] GroupFilter groupFilter)
        {
            if (ModelState.IsValid)
            {
                db.GroupFilters.Add(groupFilter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupFilter);
        }

        // GET: AdminGroupFilters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupFilter groupFilter = db.GroupFilters.Find(id);
            if (groupFilter == null)
            {
                return HttpNotFound();
            }
            return View(groupFilter);
        }

        // POST: AdminGroupFilters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupFilterId,ToDoId")] GroupFilter groupFilter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupFilter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupFilter);
        }

        // GET: AdminGroupFilters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupFilter groupFilter = db.GroupFilters.Find(id);
            if (groupFilter == null)
            {
                return HttpNotFound();
            }
            return View(groupFilter);
        }

        // POST: AdminGroupFilters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupFilter groupFilter = db.GroupFilters.Find(id);
            db.GroupFilters.Remove(groupFilter);
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
