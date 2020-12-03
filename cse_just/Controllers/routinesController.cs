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
    public class routinesController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: routines
        public ActionResult Index()
        {
            var routines = db.routines.Include(r => r.teacher);
            return View(routines.ToList());
        }

        // GET: routines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine routine = db.routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // GET: routines/Create
        public ActionResult Create()
        {
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation");
            return View();
        }

        // POST: routines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "routine_id,class_date,day,teacher_id,subject_name,subject_code,session,start_time,end_time,duration,comment")] routine routine)
        {
            if (ModelState.IsValid)
            {
                db.routines.Add(routine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation", routine.teacher_id);
            return View(routine);
        }

        // GET: routines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine routine = db.routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation", routine.teacher_id);
            return View(routine);
        }

        // POST: routines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,class_date,day,teacher_id,subject_name,subject_code,session,start_time,end_time,duration,comment")] routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation", routine.teacher_id);
            return View(routine);
        }

        // GET: routines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine routine = db.routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // POST: routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine routine = db.routines.Find(id);
            db.routines.Remove(routine);
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
