using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _420Project.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace _420Project.Controllers
{
    public class AdminAdvisorsController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAdvisors
        public ActionResult Index()
        {
            return View(db.Advisor.ToList());
        }

        // GET: AdminAdvisors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advisor advisor = db.Advisor.Find(id);
            if (advisor == null)
            {
                return HttpNotFound();
            }
            return View(advisor);
        }

        // GET: AdminAdvisors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAdvisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AdvisorId,FirstName,LastName,Office,Email,ContactNumber,IsAdmin,Password,ConfirmPassword")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = advisor.Email, Email = advisor.Email };
                var result = await UserManager.CreateAsync(user, advisor.Password);
                advisor.UserId = user.Id;
                db.Advisor.Add(advisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advisor);
        }

        // GET: AdminAdvisors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advisor advisor = db.Advisor.Find(id);
            if (advisor == null)
            {
                return HttpNotFound();
            }
            return View(advisor);
        }

        // POST: AdminAdvisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvisorId,FirstName,LastName,Office,UserId,Email,ContactNumber,IsAdmin")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advisor);
        }

        // GET: AdminAdvisors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advisor advisor = db.Advisor.Find(id);
            if (advisor == null)
            {
                return HttpNotFound();
            }
            return View(advisor);
        }

        // POST: AdminAdvisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advisor advisor = db.Advisor.Find(id);
            db.Advisor.Remove(advisor);
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
