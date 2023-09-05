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
    public class UsController : Controller
    {
        private Entities db = new Entities();

        // GET: Us
        public ActionResult Index()
        {
            var uses = db.Uses.Include(u => u.Product).Include(u => u.RawMaterial);
            return View(uses.ToList());
        }

        // GET: Us/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Us us = db.Uses.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }

        // GET: Us/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription");
            ViewBag.MaterialID = new SelectList(db.RawMaterials, "MaterialID", "MaterialName");
            return View();
        }

        // POST: Us/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialID,ProductID,GoesIntoQuantity")] Us us)
        {
            if (ModelState.IsValid)
            {
                db.Uses.Add(us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", us.ProductID);
            ViewBag.MaterialID = new SelectList(db.RawMaterials, "MaterialID", "MaterialName", us.MaterialID);
            return View(us);
        }

        // GET: Us/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Us us = db.Uses.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", us.ProductID);
            ViewBag.MaterialID = new SelectList(db.RawMaterials, "MaterialID", "MaterialName", us.MaterialID);
            return View(us);
        }

        // POST: Us/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialID,ProductID,GoesIntoQuantity")] Us us)
        {
            if (ModelState.IsValid)
            {
                db.Entry(us).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", us.ProductID);
            ViewBag.MaterialID = new SelectList(db.RawMaterials, "MaterialID", "MaterialName", us.MaterialID);
            return View(us);
        }

        // GET: Us/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Us us = db.Uses.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }

        // POST: Us/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Us us = db.Uses.Find(id);
            db.Uses.Remove(us);
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
