using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPVCalc.Models;

namespace NPVCalc.DAL
{
    public class NPVInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NPVContext>
    {

        protected override void Seed(NPVContext context)
        {
            var npv = new List<NPV>
            {
                new NPV{UpperBoundDiscountRate=1.50,LowerBoundDiscountRate=1.0,DiscountRateIncrement=0.25,CashFlows="1000,1500,2000",DateModified=DateTime.Today},
            };
            npv.ForEach(s => context.NPV.Add(s));
            context.SaveChanges();

            var npvItemResult = new List<NPVItemResult>
            {
                new NPVItemResult{Discount=1.0,NPVId=1,Period=1,NPVResult=990.09900990099,CashFlow="1000"},
                new NPVItemResult{Discount=1.25,NPVId=1,Period=1,NPVResult=987.654320987654,CashFlow="1000"},
                new NPVItemResult{Discount=1.50,NPVId=1,Period=1,NPVResult=985.221674876847,CashFlow="1000"},
                new NPVItemResult{Discount=1.0,NPVId=1,Period=2,NPVResult=1499.8500149985,CashFlow="1500"},
                new NPVItemResult{Discount=1.25,NPVId=1,Period=2,NPVResult=1499.76566161537,CashFlow="1500"},
                new NPVItemResult{Discount=1.50,NPVId=1,Period=2,NPVResult=985.221674876847,CashFlow="1500"},
                new NPVItemResult{Discount=1.0,NPVId=1,Period=3,NPVResult=1999.998000002,CashFlow="2000"},
                new NPVItemResult{Discount=1.25,NPVId=1,Period=3,NPVResult=1999.99609375763,CashFlow="2000"},
                new NPVItemResult{Discount=1.50,NPVId=1,Period=3,NPVResult=985.221674876847,CashFlow="2000"},
            };
            npvItemResult.ForEach(s => context.NPVItemResult.Add(s));
            context.SaveChanges();


        }
    }
}