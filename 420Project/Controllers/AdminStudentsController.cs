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
    public class AdminStudentsController : Controller
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

        // GET: AdminStudents
        public ActionResult Index()
        {
            var student = db.Student.Include(s => s.Advisor).Include(s => s.Campus);
            return View(student.ToList());
        }

        // GET: AdminStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: AdminStudents/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorId = new SelectList(db.Advisor, "AdvisorId", "FirstName");
            ViewBag.CampusId = new SelectList(db.Campus, "CampusID", "CampusName");
            return View();
        }

        // POST: AdminStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,FirstName,LastName,MiddleName,Email,PhoneNumber,Address,IsEnrolled,AdvisorId,Year,DOB,CampusId,Note")] Student student)
        {
            if (ModelState.IsValid)
            {


                var user = new ApplicationUser { UserName = student.Email, Email = student.Email };
                var result = await UserManager.CreateAsync(user);
                student.UserId = user.Id;
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorId = new SelectList(db.Advisor, "AdvisorId", "FirstName", student.AdvisorId);
            ViewBag.CampusId = new SelectList(db.Campus, "CampusID", "CampusName", student.CampusId);
            return View(student);
        }

        // GET: AdminStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorId = new SelectList(db.Advisor, "AdvisorId", "FirstName", student.AdvisorId);
            ViewBag.CampusId = new SelectList(db.Campus, "CampusID", "CampusName", student.CampusId);
            return View(student);
        }

        // POST: AdminStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,UserId,FirstName,LastName,MiddleName,Email,PhoneNumber,Address,IsEnrolled,AdvisorId,Year,DOB,CampusId,Note")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorId = new SelectList(db.Advisor, "AdvisorId", "FirstName", student.AdvisorId);
            ViewBag.CampusId = new SelectList(db.Campus, "CampusID", "CampusName", student.CampusId);
            return View(student);
        }

        // GET: AdminStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: AdminStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
