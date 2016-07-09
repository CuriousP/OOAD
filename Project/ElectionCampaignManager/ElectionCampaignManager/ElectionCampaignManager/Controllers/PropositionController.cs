using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectionCampaignManager.DAL;
using ElectionCampaignManager.Models;

namespace ElectionCampaignManager.Controllers
{
    public class PropositionController : Controller
    {
        private CampaignContext db = new CampaignContext();

        // GET: Proposition
        public ActionResult Index()
        {
            return View(db.Propositions.ToList());
        }

        // GET: Proposition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposition proposition = db.Propositions.Find(id);
            if (proposition == null)
            {
                return HttpNotFound();
            }
            return View(proposition);
        }

        // GET: Proposition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proposition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] Proposition proposition)
        {
            if (ModelState.IsValid)
            {
                db.Propositions.Add(proposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proposition);
        }

        // GET: Proposition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposition proposition = db.Propositions.Find(id);
            if (proposition == null)
            {
                return HttpNotFound();
            }
            return View(proposition);
        }

        // POST: Proposition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] Proposition proposition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proposition);
        }

        // GET: Proposition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposition proposition = db.Propositions.Find(id);
            if (proposition == null)
            {
                return HttpNotFound();
            }
            return View(proposition);
        }

        // POST: Proposition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposition proposition = db.Propositions.Find(id);
            db.Propositions.Remove(proposition);
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
