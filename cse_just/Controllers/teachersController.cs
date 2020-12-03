using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace cse_just.Controllers
{
    public class teachersController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: teachers
        public ActionResult Index()
        {
            var teachers = db.teachers.Include(t => t.user).Include(t => t.usertype);
            return View(teachers.ToList());
        }

        // GET: teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: teachers/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name");
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name");
            return View();
        }

        // POST: teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teacher_id,user_id,usertype_id,designation,favorite_quote,work_area,achievement,publication,publication_links,website")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", teacher.user_id);
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name", teacher.usertype_id);
            return View(teacher);
        }

        // GET: teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", teacher.user_id);
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name", teacher.usertype_id);
            return View(teacher);
        }

        // POST: teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teacher_id,user_id,usertype_id,designation,favorite_quote,work_area,achievement,publication,publication_links,website")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", teacher.user_id);
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name", teacher.usertype_id);
            return View(teacher);
        }

        // GET: teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacher teacher = db.teachers.Find(id);
            db.teachers.Remove(teacher);
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
