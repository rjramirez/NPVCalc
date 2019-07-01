using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPVCalc.Models
{
    public class NPVItemResult
    {
        public int NPVItemResultId { get; set; }
        public int NPVId { get; set; }
        public int Period { get; set; }
        public double NPVResult { get; set; }
        public double Discount { get; set; }
        public string CashFlow { get; set; }
        public virtual NPV NPV { get; set; }
    }
}