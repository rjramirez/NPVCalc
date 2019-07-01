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
using Newtonsoft.Json;
using System.Web.Script.Serialization;

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
            //else
            //{
            //    NPVItemResult npvItem = new JavaScriptSerializer().Deserialize<NPV>(nPV.NPVs);
            //    npvItem.
            //}
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
        public ActionResult Create([Bind(Include = "ID,LowerBoundDiscountRate,UpperBoundDiscountRate,DiscountRateIncrement,CashFlows,NPVs,DateModified")] NPV nPV)
        {
            if (ModelState.IsValid)
            {
                db.NPV.Add(nPV);
                nPV.DateModified = DateTime.Now;
                
                db.SaveChanges();
                GenerateNPV(nPV);

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

        public NPV GenerateNPV(NPV nPV)
        {
            double npv;
            string[] cashFlow = nPV.CashFlows.Split(',');
            NPV npvItem = new NPV();
            npvItem.CashFlows = nPV.CashFlows;
            npvItem.UpperBoundDiscountRate = nPV.UpperBoundDiscountRate;
            npvItem.LowerBoundDiscountRate = nPV.LowerBoundDiscountRate;
            npvItem.DiscountRateIncrement = nPV.DiscountRateIncrement;
            
            using (var context = new NPVContext())
            {
                db.NPVItemResult.RemoveRange(db.NPVItemResult.Where(c => c.NPVId == nPV.ID));
                db.SaveChanges();

                for (double y = nPV.LowerBoundDiscountRate; y <= nPV.UpperBoundDiscountRate; y += nPV.DiscountRateIncrement)
                {
                    for (int i = 0; i < cashFlow.Length; i++)
                    {
                        int period = i + 1;
                        npv = Convert.ToInt32(cashFlow[i]) / (1 + Math.Pow((y / 100), period));

                        context.NPVItemResult.Add(new NPVItemResult { CashFlow = cashFlow[i], Discount = y, Period = period, NPVResult = npv, NPVId = nPV.ID });
                        
                    }
                }
                context.SaveChanges();
            }

            return npvItem;
        }

        // POST: NPV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LowerBoundDiscountRate,UpperBoundDiscountRate,DiscountRateIncrement,CashFlows,NPVs,DateModified")] NPV nPV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nPV).State = EntityState.Modified;
                //var generatedNPV = GenerateNPV(nPV.CashFlows, nPV.LowerBoundDiscountRate, nPV.UpperBoundDiscountRate, nPV.DiscountRateIncrement);
                GenerateNPV(nPV);
                nPV.DateModified = DateTime.Now;

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
