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
    public class VendorsController : Controller
    {
        private Entities db = new Entities();

        // GET: Vendors
        public ActionResult Index()
        {
            var vendors = db.Vendors.Include(v => v.Supply);
            return View(vendors.ToList());
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            ViewBag.VendorID = new SelectList(db.Supplies, "VendorID", "VendorID");
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,VendorName,VendorAddress,VendorCity,VendorState,VendorZipCode")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorID = new SelectList(db.Supplies, "VendorID", "VendorID", vendor.VendorID);
            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorID = new SelectList(db.Supplies, "VendorID", "VendorID", vendor.VendorID);
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VendorName,VendorAddress,VendorCity,VendorState,VendorZipCode")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorID = new SelectList(db.Supplies, "VendorID", "VendorID", vendor.VendorID);
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
