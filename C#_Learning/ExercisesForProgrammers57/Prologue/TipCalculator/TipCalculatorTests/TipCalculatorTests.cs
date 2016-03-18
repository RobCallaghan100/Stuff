using System;
using NUnit.Framework;

namespace TipCalculator
{
    [TestFixture]
    public class TipCalculatorTests
    {
        [TestCase(100, 15, 115)]
        [TestCase(110, 7.5, 118.25)]
        [TestCase(11.25, 15, 12.94)]
        [TestCase(9.81, 0, 9.81)]
        public void ShouldReturn115IfBillAmount100AndTip15(decimal billAmount, decimal tip, decimal expectedTotalAmount)
        {
            var tipCalculator = new TipCalculator();

            var result = tipCalculator.Calculate(billAmount, tip);

            Assert.That(result, Is.EqualTo(expectedTotalAmount));
        }

        [Test]
        public void ShouldThrowExceptionIfTipBelowZero(decimal billAmount, decimal tip, decimal expectedTotalAmount)
        {
            var tipCalculator = new TipCalculator();

            var result = tipCalculator.Calculate(billAmount, tip);

            Assert.Throws(typeof(Exception), ))
        }
    }
}
