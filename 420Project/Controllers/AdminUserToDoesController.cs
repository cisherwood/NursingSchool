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
    public class AdminUserToDoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminUserToDoes
        public ActionResult Index()
        {
            return View(db.UserToDos.ToList());
        }

        // GET: AdminUserToDoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToDo userToDo = db.UserToDos.Find(id);
            if (userToDo == null)
            {
                return HttpNotFound();
            }
            return View(userToDo);
        }

        // GET: AdminUserToDoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUserToDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserToDoId,ToDoId,UserId,isComplete")] UserToDo userToDo)
        {
            if (ModelState.IsValid)
            {
                db.UserToDos.Add(userToDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userToDo);
        }

        // GET: AdminUserToDoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToDo userToDo = db.UserToDos.Find(id);
            if (userToDo == null)
            {
                return HttpNotFound();
            }
            return View(userToDo);
        }

        // POST: AdminUserToDoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserToDoId,ToDoId,UserId,isComplete")] UserToDo userToDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userToDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userToDo);
        }

        // GET: AdminUserToDoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToDo userToDo = db.UserToDos.Find(id);
            if (userToDo == null)
            {
                return HttpNotFound();
            }
            return View(userToDo);
        }

        // POST: AdminUserToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserToDo userToDo = db.UserToDos.Find(id);
            db.UserToDos.Remove(userToDo);
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
