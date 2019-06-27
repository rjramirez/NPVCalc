using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NPVCalc.DAL;
using NPVCalc.Models;

namespace NPVCalc.Controllers
{
    public class NPVController : Controller
    {
        private NPVContext db = new NPVContext();

        // GET: NPV
        public ActionResult Index()
        {
            return View(db.NPV.ToList());
        }

        // GET: NPV/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NPV nPV = db.NPV.Find(id);
            if (nPV == null)
            {
                return HttpNotFound();
            }
            return View(nPV);
        }

        // GET: NPV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NPV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NPVId,LowerBoundDiscountRate,UpperBoundDiscountRate,DiscountRateIncrement,CashFlows")] NPV nPV)
        {
            if (ModelState.IsValid)
            {
                db.NPV.Add(nPV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nPV);
        }

        // GET: NPV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NPV nPV = db.NPV.Find(id);
            if (nPV == null)
            {
                return HttpNotFound();
            }
            return View(nPV);
        }

        public string CalculateNPV(string cashFlow,double upDiscRate, double lowDiscRate)
        {
            string npvString = "";
            double npv;
            string[] cashFlows = cashFlow.Split();

            return npvString;
        }

        // POST: NPV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NPVId,LowerBoundDiscountRate,UpperBoundDiscountRate,DiscountRateIncrement,CashFlows")] NPV nPV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nPV).State = EntityState.Modified;
                int npv = Convert.ToInt32(CalculateNPV(nPV.CashFlows, nPV.UpperBoundDiscountRate, nPV.LowerBoundDiscountRate));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nPV);
        }

        // GET: NPV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NPV nPV = db.NPV.Find(id);
            if (nPV == null)
            {
                return HttpNotFound();
            }
            return View(nPV);
        }

        // POST: NPV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NPV nPV = db.NPV.Find(id);
            db.NPV.Remove(nPV);
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
