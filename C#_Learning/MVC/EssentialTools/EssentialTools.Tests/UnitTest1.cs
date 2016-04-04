using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialTools.Tests
{
    using Models;

    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void DiscountAbove100()
        {
            var target = getTestObject();
            decimal total = 200;

            var result = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, result);
        }

        [TestMethod]
        public void DiscountBetween10And100()
        {
            var target = getTestObject();

            decimal tenDollarDiscount = target.ApplyDiscount(10);
            decimal fiftyDollarDiscount = target.ApplyDiscount(50);
            decimal oneHundredDollarDiscount = target.ApplyDiscount(100);

            Assert.AreEqual(5, tenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(45, fiftyDollarDiscount, "$50 discount is wrong");
            Assert.AreEqual(95, oneHundredDollarDiscount, "$100 discount is wrong");
        }

        [TestMethod]
        public void DiscountLessThan10()
        {
            var target = getTestObject();

            var result1 = target.ApplyDiscount(9);
            var result2 = target.ApplyDiscount(0);

            Assert.AreEqual(9, result1);
            Assert.AreEqual(0, result2);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void DiscountNegativeTotal()
        {
            var target = getTestObject();

            target.ApplyDiscount(-1);
        }
    }
}
