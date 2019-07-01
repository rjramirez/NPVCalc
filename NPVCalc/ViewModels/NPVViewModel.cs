using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPVCalc.ViewModels
{
    public class NPVViewModel
    {
        public Guid Id { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double DiscountRateIncrement { get; set; }
        public string CashFlows { get; set; }
        public virtual ICollection<NPVViewModel> NPVResultList { get; set; }
    }
}