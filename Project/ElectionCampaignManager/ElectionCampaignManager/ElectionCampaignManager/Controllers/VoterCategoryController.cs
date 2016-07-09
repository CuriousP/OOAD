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
    public class VoterCategoryController : Controller
    {
        private CampaignContext db = new CampaignContext();

        // GET: VoterCategory
        public ActionResult Index()
        {
            var voterCategories = db.VoterCategories.Include(v => v.Category).Include(v => v.Voter);
            return View(voterCategories.ToList());
        }

        // GET: VoterCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterCategory voterCategory = db.VoterCategories.Find(id);
            if (voterCategory == null)
            {
                return HttpNotFound();
            }
            return View(voterCategory);
        }

        // GET: VoterCategory/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "ID", "Description");
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name");
            return View();
        }

        // POST: VoterCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoterCategoryId,VoterId,CategoryId")] VoterCategory voterCategory)
        {
            if (ModelState.IsValid)
            {
                db.VoterCategories.Add(voterCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "ID", "Description", voterCategory.CategoryId);
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name", voterCategory.VoterId);
            return View(voterCategory);
        }

        // GET: VoterCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterCategory voterCategory = db.VoterCategories.Find(id);
            if (voterCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "ID", "Description", voterCategory.CategoryId);
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name", voterCategory.VoterId);
            return View(voterCategory);
        }

        // POST: VoterCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoterCategoryId,VoterId,CategoryId")] VoterCategory voterCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voterCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "ID", "Description", voterCategory.CategoryId);
            ViewBag.VoterId = new SelectList(db.Voters, "ID", "First_Name", voterCategory.VoterId);
            return View(voterCategory);
        }

        // GET: VoterCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterCategory voterCategory = db.VoterCategories.Find(id);
            if (voterCategory == null)
            {
                return HttpNotFound();
            }
            return View(voterCategory);
        }

        // POST: VoterCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoterCategory voterCategory = db.VoterCategories.Find(id);
            db.VoterCategories.Remove(voterCategory);
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
