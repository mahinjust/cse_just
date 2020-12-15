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
    public class usertypesController : Controller
    {
        private csejustEntities db = new csejustEntities();

        // GET: usertypes
        public ActionResult Index()
        {
            return View(db.usertypes.ToList());
        }

        // GET: usertypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usertype usertype = db.usertypes.Find(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        // GET: usertypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usertypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usertype_id,usertype_name")] usertype usertype)
        {
            if (ModelState.IsValid)
            {
                db.usertypes.Add(usertype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usertype);
        }

        // GET: usertypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usertype usertype = db.usertypes.Find(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        // POST: usertypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usertype_id,usertype_name")] usertype usertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usertype);
        }

        // GET: usertypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usertype usertype = db.usertypes.Find(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        // POST: usertypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usertype usertype = db.usertypes.Find(id);
            db.usertypes.Remove(usertype);
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
