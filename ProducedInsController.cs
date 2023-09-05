using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S2G7_PVFAPP.Models;

namespace S2G7_PVFAPP.Controllers
{
    public class ProducedInsController : Controller
    {
        private Entities db = new Entities();

        // GET: ProducedIns
        public ActionResult Index()
        {
            var producedIns = db.ProducedIns.Include(p => p.Product).Include(p => p.WorkCenter);
            return View(producedIns.ToList());
        }

        // GET: ProducedIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducedIn producedIn = db.ProducedIns.Find(id);
            if (producedIn == null)
            {
                return HttpNotFound();
            }
            return View(producedIn);
        }

        // GET: ProducedIns/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription");
            ViewBag.WorkCenterID = new SelectList(db.WorkCenters, "WorkCenterID", "WorkCenterLocation");
            return View();
        }

        // POST: ProducedIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkCenterID,ProductID,Rating")] ProducedIn producedIn)
        {
            if (ModelState.IsValid)
            {
                db.ProducedIns.Add(producedIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", producedIn.ProductID);
            ViewBag.WorkCenterID = new SelectList(db.WorkCenters, "WorkCenterID", "WorkCenterLocation", producedIn.WorkCenterID);
            return View(producedIn);
        }

        // GET: ProducedIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducedIn producedIn = db.ProducedIns.Find(id);
            if (producedIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", producedIn.ProductID);
            ViewBag.WorkCenterID = new SelectList(db.WorkCenters, "WorkCenterID", "WorkCenterLocation", producedIn.WorkCenterID);
            return View(producedIn);
        }

        // POST: ProducedIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkCenterID,ProductID,Rating")] ProducedIn producedIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producedIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", producedIn.ProductID);
            ViewBag.WorkCenterID = new SelectList(db.WorkCenters, "WorkCenterID", "WorkCenterLocation", producedIn.WorkCenterID);
            return View(producedIn);
        }

        // GET: ProducedIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducedIn producedIn = db.ProducedIns.Find(id);
            if (producedIn == null)
            {
                return HttpNotFound();
            }
            return View(producedIn);
        }

        // POST: ProducedIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducedIn producedIn = db.ProducedIns.Find(id);
            db.ProducedIns.Remove(producedIn);
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
