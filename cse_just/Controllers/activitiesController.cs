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
    public class activitiesController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: activities
        public ActionResult Index()
        {
            var activities = db.activities.Include(a => a.student);
            return View(activities.ToList());
        }

        // GET: activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: activities/Create
        public ActionResult Create()
        {
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills");
            return View();
        }

        // POST: activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_id,club_membership,designation,achievement,others_co_curricular_activities,description")] activity activity)
        {
            if (ModelState.IsValid)
            {
                db.activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", activity.student_id);
            return View(activity);
        }

        // GET: activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", activity.student_id);
            return View(activity);
        }

        // POST: activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,club_membership,designation,achievement,others_co_curricular_activities,description")] activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "skills", activity.student_id);
            return View(activity);
        }

        // GET: activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            activity activity = db.activities.Find(id);
            db.activities.Remove(activity);
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
