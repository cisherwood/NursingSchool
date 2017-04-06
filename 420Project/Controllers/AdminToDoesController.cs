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
    public class AdminToDoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminToDoes
        public ActionResult Index()
        {
            return View(db.To_Dos.ToList());
        }

        // GET: AdminToDoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.To_Dos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // GET: AdminToDoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminToDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToDoID,Description,CreateDate,DueDate")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.To_Dos.Add(toDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDo);
        }

        // GET: AdminToDoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.To_Dos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // POST: AdminToDoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToDoID,Description,CreateDate,DueDate")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDo);
        }

        // GET: AdminToDoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.To_Dos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // POST: AdminToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo toDo = db.To_Dos.Find(id);
            db.To_Dos.Remove(toDo);
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
