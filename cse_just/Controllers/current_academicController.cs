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
    public class current_academicController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: current_academic
        public ActionResult Index()
        {
            var current_academic = db.current_academic.Include(c => c.student).Include(c => c.user);
            return View(current_academic.ToList());
        }

        // GET: current_academic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            current_academic current_academic = db.current_academic.Find(id);
            if (current_academic == null)
            {
                return HttpNotFound();
            }
            return View(current_academic);
        }

        // GET: current_academic/Create
        public ActionResult Create()
        {
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills");
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name");
            return View();
        }

        // POST: current_academic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,student_id,admission_date,session,dept,last_semester_result,current_year,current_semester")] current_academic current_academic)
        {
            if (ModelState.IsValid)
            {
                db.current_academic.Add(current_academic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", current_academic.student_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", current_academic.user_id);
            return View(current_academic);
        }

        // GET: current_academic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            current_academic current_academic = db.current_academic.Find(id);
            if (current_academic == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", current_academic.student_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", current_academic.user_id);
            return View(current_academic);
        }

        // POST: current_academic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,student_id,admission_date,session,dept,last_semester_result,current_year,current_semester")] current_academic current_academic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(current_academic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", current_academic.student_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", current_academic.user_id);
            return View(current_academic);
        }

        // GET: current_academic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            current_academic current_academic = db.current_academic.Find(id);
            if (current_academic == null)
            {
                return HttpNotFound();
            }
            return View(current_academic);
        }

        // POST: current_academic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            current_academic current_academic = db.current_academic.Find(id);
            db.current_academic.Remove(current_academic);
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
