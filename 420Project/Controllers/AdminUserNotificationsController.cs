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
    public class AdminUserNotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminUserNotifications
        public ActionResult Index()
        {
            return View(db.UserNotifications.ToList());
        }

        // GET: AdminUserNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserNotification userNotification = db.UserNotifications.Find(id);
            if (userNotification == null)
            {
                return HttpNotFound();
            }
            return View(userNotification);
        }

        // GET: AdminUserNotifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUserNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserNotificationId,NotificationId,UserId,isComplete")] UserNotification userNotification)
        {
            if (ModelState.IsValid)
            {
                db.UserNotifications.Add(userNotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userNotification);
        }

        // GET: AdminUserNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserNotification userNotification = db.UserNotifications.Find(id);
            if (userNotification == null)
            {
                return HttpNotFound();
            }
            return View(userNotification);
        }

        // POST: AdminUserNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserNotificationId,NotificationId,UserId,isComplete")] UserNotification userNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userNotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userNotification);
        }

        // GET: AdminUserNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserNotification userNotification = db.UserNotifications.Find(id);
            if (userNotification == null)
            {
                return HttpNotFound();
            }
            return View(userNotification);
        }

        // POST: AdminUserNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserNotification userNotification = db.UserNotifications.Find(id);
            db.UserNotifications.Remove(userNotification);
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
