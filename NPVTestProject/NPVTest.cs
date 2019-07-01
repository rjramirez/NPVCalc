using NPVCalc.Controllers;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPVCalc.Models;

namespace NPVTestProject
{
    [TestClass]
    public class NPVTest
    {
        private const double ExpectedNPV = 990.09900990099;
        NPV npv = new NPV();
        NPVItemResult npvItemResult = new NPVItemResult();


        [TestMethod]
        public void NPVTestCalculate()
        {

        }

        [TestMethod()]
        public void GenerateNPVTest()
        {
            NPVCalc.Controllers.NPVController npvControl = new NPVController();
            


            Assert.Fail();
        }
    }
}
