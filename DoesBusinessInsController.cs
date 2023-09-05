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
    public class DoesBusinessInsController : Controller
    {
        private Entities db = new Entities();

        // GET: DoesBusinessIns
        public ActionResult Index()
        {
            var doesBusinessIns = db.DoesBusinessIns.Include(d => d.Customer).Include(d => d.SalesTerritory);
            return View(doesBusinessIns.ToList());
        }

        // GET: DoesBusinessIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIns.Find(id);
            if (doesBusinessIn == null)
            {
                return HttpNotFound();
            }
            return View(doesBusinessIn);
        }

        // GET: DoesBusinessIns/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.TerritoryID = new SelectList(db.SalesTerritories, "TerritoryID", "TerritoryName");
            return View();
        }

        // POST: DoesBusinessIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerritoryID,CustomerID,Revenue")] DoesBusinessIn doesBusinessIn)
        {
            if (ModelState.IsValid)
            {
                db.DoesBusinessIns.Add(doesBusinessIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", doesBusinessIn.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.SalesTerritories, "TerritoryID", "TerritoryName", doesBusinessIn.TerritoryID);
            return View(doesBusinessIn);
        }

        // GET: DoesBusinessIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIns.Find(id);
            if (doesBusinessIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", doesBusinessIn.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.SalesTerritories, "TerritoryID", "TerritoryName", doesBusinessIn.TerritoryID);
            return View(doesBusinessIn);
        }

        // POST: DoesBusinessIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerritoryID,CustomerID,Revenue")] DoesBusinessIn doesBusinessIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doesBusinessIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", doesBusinessIn.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.SalesTerritories, "TerritoryID", "TerritoryName", doesBusinessIn.TerritoryID);
            return View(doesBusinessIn);
        }

        // GET: DoesBusinessIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIns.Find(id);
            if (doesBusinessIn == null)
            {
                return HttpNotFound();
            }
            return View(doesBusinessIn);
        }

        // POST: DoesBusinessIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIns.Find(id);
            db.DoesBusinessIns.Remove(doesBusinessIn);
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
