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
    public class previous_academicController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: previous_academic
        public ActionResult Index()
        {
            var previous_academic = db.previous_academic.Include(p => p.student).Include(p => p.user);
            return View(previous_academic.ToList());
        }

        // GET: previous_academic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            previous_academic previous_academic = db.previous_academic.Find(id);
            if (previous_academic == null)
            {
                return HttpNotFound();
            }
            return View(previous_academic);
        }

        // GET: previous_academic/Create
        public ActionResult Create()
        {
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills");
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name");
            return View();
        }

        // POST: previous_academic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,student_id,hsc_roll,hsc_reg,hsc_result,hsc_board,hsc_college,hsc_section,ssc_roll,ssc_reg,ssc_result,ssc_board,ssc_school,ssc_section")] previous_academic previous_academic)
        {
            if (ModelState.IsValid)
            {
                db.previous_academic.Add(previous_academic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", previous_academic.student_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", previous_academic.user_id);
            return View(previous_academic);
        }

        // GET: previous_academic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            previous_academic previous_academic = db.previous_academic.Find(id);
            if (previous_academic == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", previous_academic.student_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", previous_academic.user_id);
            return View(previous_academic);
        }

        // POST: previous_academic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,student_id,hsc_roll,hsc_reg,hsc_result,hsc_board,hsc_college,hsc_section,ssc_roll,ssc_reg,ssc_result,ssc_board,ssc_school,ssc_section")] previous_academic previous_academic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previous_academic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", previous_academic.student_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", previous_academic.user_id);
            return View(previous_academic);
        }

        // GET: previous_academic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            previous_academic previous_academic = db.previous_academic.Find(id);
            if (previous_academic == null)
            {
                return HttpNotFound();
            }
            return View(previous_academic);
        }

        // POST: previous_academic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            previous_academic previous_academic = db.previous_academic.Find(id);
            db.previous_academic.Remove(previous_academic);
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
