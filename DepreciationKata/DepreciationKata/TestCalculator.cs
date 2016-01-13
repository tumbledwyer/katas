using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DepreciationKata
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly Calculator _calculator = new Calculator();

        [Test]
        public void MonthTillYearEnd_AMonthApart_ShouldReturn1()
        {
            //---------------Set up test pack-------------------
            var initialDate = new DateTime(2016,7,31);
            var yearEnd = new DateTime(2016,8,31);
            const int monthsApart = 1;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var months = _calculator.MonthsTillYearEnd(yearEnd, initialDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(monthsApart, months);
        }

        [Test]
        public void MonthTillYearEnd_3MonthApart_ShouldReturn3()
        {
            //---------------Set up test pack-------------------
            var initialDate = new DateTime(2016,7,31);
            var yearEnd = new DateTime(2016,10,31);
            const int monthsApart = 3;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var months = _calculator.MonthsTillYearEnd(yearEnd, initialDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(monthsApart, months);
        }
        
        [Test]
        public void GetMonthlyDepreciation_Given12000LossIn1Year_ShouldReturn1000()
        {
            //---------------Set up test pack-------------------
            var asset = new Asset
            {
                Cost = 13000,
                Residual = 1000,
                Life = 1
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var monthlyDepreciation = _calculator.GetMonthlyDepreciation(asset);
            //---------------Test Result -----------------------
            Assert.AreEqual(1000, monthlyDepreciation);
        }

        [Test]
        public void Loss_Given1000MonthlyDepreciationAnd10MonthsTillYearEnd_ShouldReturn10000()
        {
            //---------------Set up test pack-------------------
            var monthlyDepreciation = 1000;
            var months = 10;
            var expectedLoss = 10000;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var loss = _calculator.Loss(monthlyDepreciation, months);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedLoss, loss);
        }

        [Test]
        public void Loss_Given2000MonthlyDepreciationAnd10MonthsTillYearEnd_ShouldReturn20000()
        {
            //---------------Set up test pack-------------------
            var monthlyDepreciation = 2000;
            var months = 10;
            var expectedLoss = 20000;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var loss = _calculator.Loss(monthlyDepreciation, months);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedLoss, loss);
        }
    }

    public class Asset
    {
        public decimal Cost { get; set; }
        public decimal Residual { get; set; }
        public int Life { get; set; }
    }
}
