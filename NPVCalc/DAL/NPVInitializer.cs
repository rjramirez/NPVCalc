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
                new NPV{UpperBoundDiscountRate=15.0,LowerBoundDiscountRate=1.0,DiscountRateIncrement=0.25,CashFlows="1000,1500,2000"},
            };

            npv.ForEach(s => context.NPV.Add(s));
            context.SaveChanges();
        }
    }
}