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
    public class carrier_tController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: carrier_t
        public ActionResult Index()
        {
            var carrier_t = db.carrier_t.Include(c => c.teacher);
            return View(carrier_t.ToList());
        }

        // GET: carrier_t/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrier_t carrier_t = db.carrier_t.Find(id);
            if (carrier_t == null)
            {
                return HttpNotFound();
            }
            return View(carrier_t);
        }

        // GET: carrier_t/Create
        public ActionResult Create()
        {
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation");
            return View();
        }

        // POST: carrier_t/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teacher_id,joining_date,phd_status,phd_institute,msc_status,msc_institute,msc_session,msc_result,bsc_status,bsc_institute,bsc_session,bsc_result,ex_institute,join_date,leave_date")] carrier_t carrier_t)
        {
            if (ModelState.IsValid)
            {
                db.carrier_t.Add(carrier_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation", carrier_t.teacher_id);
            return View(carrier_t);
        }

        // GET: carrier_t/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrier_t carrier_t = db.carrier_t.Find(id);
            if (carrier_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation", carrier_t.teacher_id);
            return View(carrier_t);
        }

        // POST: carrier_t/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teacher_id,joining_date,phd_status,phd_institute,msc_status,msc_institute,msc_session,msc_result,bsc_status,bsc_institute,bsc_session,bsc_result,ex_institute,join_date,leave_date")] carrier_t carrier_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrier_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "designation", carrier_t.teacher_id);
            return View(carrier_t);
        }

        // GET: carrier_t/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrier_t carrier_t = db.carrier_t.Find(id);
            if (carrier_t == null)
            {
                return HttpNotFound();
            }
            return View(carrier_t);
        }

        // POST: carrier_t/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carrier_t carrier_t = db.carrier_t.Find(id);
            db.carrier_t.Remove(carrier_t);
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
