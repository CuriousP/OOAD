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
    public class VendorPaymentController : Controller
    {
        private CampaignContext db = new CampaignContext();

        // GET: VendorPayment
        public ActionResult Index()
        {
            return View(db.VendorPayments.ToList());
        }

        // GET: VendorPayment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorPayment vendorPayment = db.VendorPayments.Find(id);
            if (vendorPayment == null)
            {
                return HttpNotFound();
            }
            return View(vendorPayment);
        }

        // GET: VendorPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorPayment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vendor_Name,Payment_Date,Amount")] VendorPayment vendorPayment)
        {
            if (ModelState.IsValid)
            {
                db.VendorPayments.Add(vendorPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorPayment);
        }

        // GET: VendorPayment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorPayment vendorPayment = db.VendorPayments.Find(id);
            if (vendorPayment == null)
            {
                return HttpNotFound();
            }
            return View(vendorPayment);
        }

        // POST: VendorPayment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vendor_Name,Payment_Date,Amount")] VendorPayment vendorPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorPayment);
        }

        // GET: VendorPayment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorPayment vendorPayment = db.VendorPayments.Find(id);
            if (vendorPayment == null)
            {
                return HttpNotFound();
            }
            return View(vendorPayment);
        }

        // POST: VendorPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorPayment vendorPayment = db.VendorPayments.Find(id);
            db.VendorPayments.Remove(vendorPayment);
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
