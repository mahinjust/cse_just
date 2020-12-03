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
    public class studentsController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: students
        public ActionResult Index()
        {
            var students = db.students.Include(s => s.user).Include(s => s.usertype);
            return View(students.ToList());
        }

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name");
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name");
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_id,user_id,usertype_id,quota,skills,hobby,fathers_name,fathers_occupassion,fathers_contact_no,mothers_name,mothers_occupassion,mothers_contact_no,guardians_name,guardians_occupassion,guardians_contact_no")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", student.user_id);
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name", student.usertype_id);
            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", student.user_id);
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name", student.usertype_id);
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,user_id,usertype_id,quota,skills,hobby,fathers_name,fathers_occupassion,fathers_contact_no,mothers_name,mothers_occupassion,mothers_contact_no,guardians_name,guardians_occupassion,guardians_contact_no")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "first_name", student.user_id);
            ViewBag.usertype_id = new SelectList(db.usertypes, "usertype_id", "usertype_name", student.usertype_id);
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
