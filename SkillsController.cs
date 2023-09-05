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
    public class SkillsController : Controller
    {
        private Entities db = new Entities();

        // GET: Skills
        public ActionResult Index()
        {
            var skills = db.Skills.Include(s => s.HasSkill);
            return View(skills.ToList());
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            ViewBag.SkillCode = new SelectList(db.HasSkills, "SkillCode", "SkillCode");
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillCode,SkillDescription")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkillCode = new SelectList(db.HasSkills, "SkillCode", "SkillCode", skill.SkillCode);
            return View(skill);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillCode = new SelectList(db.HasSkills, "SkillCode", "SkillCode", skill.SkillCode);
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillCode,SkillDescription")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillCode = new SelectList(db.HasSkills, "SkillCode", "SkillCode", skill.SkillCode);
            return View(skill);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
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
