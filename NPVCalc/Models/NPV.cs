using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPVCalc.Models
{
    public class NPV
    {
        public int NPVId { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double DiscountRateIncrement { get; set; }
        public string CashFlows { get; set; }
        public double[] NPVs { get; set; }
    }
}