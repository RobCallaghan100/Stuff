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

        [TestCase(100, -1, 0)]
        public void ShouldThrowExceptionIfTipBelowZero(decimal billAmount, decimal tip, decimal expectedTotalAmount)
        {
            var tipCalculator = new TipCalculator();

            Assert.That(() => tipCalculator.Calculate(billAmount, tip), Throws.TypeOf<Exception>());
        }
    }
}
