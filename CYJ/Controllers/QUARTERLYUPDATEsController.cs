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
    [Authorize]
    public class QUARTERLYUPDATEsController : Controller
    {
        private cyjEntities2 db = new cyjEntities2();

        // GET: QUARTERLYUPDATEs
        public ActionResult Index()
        {
            return View(db.QUARTERLYUPDATEs.ToList());
        }
        [Authorize(Roles = "Admin, Observer, Writer, Approver")]
        public ActionResult Home()
        {
            return View(db.ABOUTs.ToList());
        }
        // GET: QUARTERLYUPDATEs/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUARTERLYUPDATEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "updateID,updateHeader,updateBody,updateDate")] QUARTERLYUPDATE qUARTERLYUPDATE)
        {
                db.QUARTERLYUPDATEs.Add(qUARTERLYUPDATE);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: QUARTERLYUPDATEs/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTERLYUPDATE qUARTERLYUPDATE = db.QUARTERLYUPDATEs.Find(id);
            if (qUARTERLYUPDATE == null)
            {
                return HttpNotFound();
            }
            return View(qUARTERLYUPDATE);
        }

        // POST: QUARTERLYUPDATEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "updateID,updateHeader,updateBody,updateDate")] QUARTERLYUPDATE qUARTERLYUPDATE)
        {
                db.Entry(qUARTERLYUPDATE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: QUARTERLYUPDATEs/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTERLYUPDATE qUARTERLYUPDATE = db.QUARTERLYUPDATEs.Find(id);
            if (qUARTERLYUPDATE == null)
            {
                return HttpNotFound();
            }
            return View(qUARTERLYUPDATE);
        }

        // POST: QUARTERLYUPDATEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            QUARTERLYUPDATE qUARTERLYUPDATE = db.QUARTERLYUPDATEs.Find(id);
            db.QUARTERLYUPDATEs.Remove(qUARTERLYUPDATE);
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
