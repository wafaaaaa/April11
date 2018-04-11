using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize(Roles ="Admin, Observer")]
    public class ABOUTs1Controller : Controller
    {
        private cyjEntities2 db = new cyjEntities2();

        // GET: ABOUTs1
        [Authorize(Roles = "Admin, Observer, Writer, Approver")]
        public ActionResult Index()
        {
            return View(db.ABOUTs.ToList());
        }
        [Authorize(Roles = "Admin, Observer, Writer, Approver")]
        public ActionResult Home()
        {
            return View(db.ABOUTs.ToList());
        }

        // GET: ABOUTs1/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ABOUTs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "aboutID,aboutHeader,aboutBody")] ABOUT aBOUT)
        {
                db.ABOUTs.Add(aBOUT);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: ABOUTs1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // POST: ABOUTs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "aboutID,aboutHeader,aboutBody")] ABOUT aBOUT)
        {
                db.Entry(aBOUT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: ABOUTs1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // POST: ABOUTs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ABOUT aBOUT = db.ABOUTs.Find(id);
            db.ABOUTs.Remove(aBOUT);
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
