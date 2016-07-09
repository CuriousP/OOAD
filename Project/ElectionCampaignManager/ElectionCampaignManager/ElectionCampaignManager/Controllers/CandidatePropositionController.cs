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
    public class CandidatePropositionController : Controller
    {
        private CampaignContext db = new CampaignContext();

        // GET: CandidateProposition
        public ActionResult Index()
        {
            var candidatePropositions = db.CandidatePropositions.Include(c => c.Candidate).Include(c => c.Proposition);
            return View(candidatePropositions.ToList());
        }

        // GET: CandidateProposition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateProposition candidateProposition = db.CandidatePropositions.Find(id);
            if (candidateProposition == null)
            {
                return HttpNotFound();
            }
            return View(candidateProposition);
        }

        // GET: CandidateProposition/Create
        public ActionResult Create()
        {
            ViewBag.CandidateId = new SelectList(db.Candidates, "ID", "Name");
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description");
            return View();
        }

        // POST: CandidateProposition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidatePropositionId,CandidateId,PropositionId")] CandidateProposition candidateProposition)
        {
            if (ModelState.IsValid)
            {
                db.CandidatePropositions.Add(candidateProposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateId = new SelectList(db.Candidates, "ID", "Name", candidateProposition.CandidateId);
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description", candidateProposition.PropositionId);
            return View(candidateProposition);
        }

        // GET: CandidateProposition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateProposition candidateProposition = db.CandidatePropositions.Find(id);
            if (candidateProposition == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "ID", "Name", candidateProposition.CandidateId);
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description", candidateProposition.PropositionId);
            return View(candidateProposition);
        }

        // POST: CandidateProposition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidatePropositionId,CandidateId,PropositionId")] CandidateProposition candidateProposition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateProposition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "ID", "Name", candidateProposition.CandidateId);
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description", candidateProposition.PropositionId);
            return View(candidateProposition);
        }

        // GET: CandidateProposition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateProposition candidateProposition = db.CandidatePropositions.Find(id);
            if (candidateProposition == null)
            {
                return HttpNotFound();
            }
            return View(candidateProposition);
        }

        // POST: CandidateProposition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateProposition candidateProposition = db.CandidatePropositions.Find(id);
            db.CandidatePropositions.Remove(candidateProposition);
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
