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
    public class VoterPropositionController : Controller
    {
        private CampaignContext db = new CampaignContext();

        // GET: VoterProposition
        public ActionResult Index()
        {
            var voterPropositions = db.VoterPropositions.Include(v => v.Proposition).Include(v => v.Voter);
            return View(voterPropositions.ToList());
        }

        // GET: VoterProposition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterProposition voterProposition = db.VoterPropositions.Find(id);
            if (voterProposition == null)
            {
                return HttpNotFound();
            }
            return View(voterProposition);
        }

        // GET: VoterProposition/Create
        public ActionResult Create()
        {
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description");
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name");
            return View();
        }

        // POST: VoterProposition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoterPropositionId,VoterId,PropositionId")] VoterProposition voterProposition)
        {
            if (ModelState.IsValid)
            {
                db.VoterPropositions.Add(voterProposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description", voterProposition.PropositionId);
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name", voterProposition.VoterId);
            return View(voterProposition);
        }

        // GET: VoterProposition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterProposition voterProposition = db.VoterPropositions.Find(id);
            if (voterProposition == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description", voterProposition.PropositionId);
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name", voterProposition.VoterId);
            return View(voterProposition);
        }

        // POST: VoterProposition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoterPropositionId,VoterId,PropositionId")] VoterProposition voterProposition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voterProposition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropositionId = new SelectList(db.Propositions, "ID", "Description", voterProposition.PropositionId);
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name", voterProposition.VoterId);
            return View(voterProposition);
        }

        // GET: VoterProposition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterProposition voterProposition = db.VoterPropositions.Find(id);
            if (voterProposition == null)
            {
                return HttpNotFound();
            }
            return View(voterProposition);
        }

        // POST: VoterProposition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoterProposition voterProposition = db.VoterPropositions.Find(id);
            db.VoterPropositions.Remove(voterProposition);
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
