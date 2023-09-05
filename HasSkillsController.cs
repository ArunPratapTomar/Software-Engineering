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
    public class HasSkillsController : Controller
    {
        private Entities db = new Entities();

        // GET: HasSkills
        public ActionResult Index()
        {
            var hasSkills = db.HasSkills.Include(h => h.Employee).Include(h => h.Skill);
            return View(hasSkills.ToList());
        }

        // GET: HasSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasSkill hasSkill = db.HasSkills.Find(id);
            if (hasSkill == null)
            {
                return HttpNotFound();
            }
            return View(hasSkill);
        }

        // GET: HasSkills/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            ViewBag.SkillCode = new SelectList(db.Skills, "SkillCode", "SkillDescription");
            return View();
        }

        // POST: HasSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillCode,EmployeeID,Experience")] HasSkill hasSkill)
        {
            if (ModelState.IsValid)
            {
                db.HasSkills.Add(hasSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", hasSkill.EmployeeID);
            ViewBag.SkillCode = new SelectList(db.Skills, "SkillCode", "SkillDescription", hasSkill.SkillCode);
            return View(hasSkill);
        }

        // GET: HasSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasSkill hasSkill = db.HasSkills.Find(id);
            if (hasSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", hasSkill.EmployeeID);
            ViewBag.SkillCode = new SelectList(db.Skills, "SkillCode", "SkillDescription", hasSkill.SkillCode);
            return View(hasSkill);
        }

        // POST: HasSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillCode,EmployeeID,Experience")] HasSkill hasSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hasSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", hasSkill.EmployeeID);
            ViewBag.SkillCode = new SelectList(db.Skills, "SkillCode", "SkillDescription", hasSkill.SkillCode);
            return View(hasSkill);
        }

        // GET: HasSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasSkill hasSkill = db.HasSkills.Find(id);
            if (hasSkill == null)
            {
                return HttpNotFound();
            }
            return View(hasSkill);
        }

        // POST: HasSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HasSkill hasSkill = db.HasSkills.Find(id);
            db.HasSkills.Remove(hasSkill);
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
