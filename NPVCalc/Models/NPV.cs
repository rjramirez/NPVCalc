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
        public string NPVs { get; set; }
        public List<NPVItemResult> NPVList { get; set; }
    }

    public class NPVItemResult
    {
        public int NPVItemResultId { get; set; }
        public int Period { get; set; }
        public double NPVResult { get; set; }
        public double Discount { get; set; }
        public NPV NPV { get; set; }
    }


}