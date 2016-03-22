using System;
using NUnit.Framework;
using SchedulerServices.Parsers;

namespace SchedulerServicesTests.Parsers
{
    [TestFixture]
    public class YahooFinanceParserTests
    {
        private YahooFinanceParser _yahooFinanceParser;

        [SetUp]
        public void Setup()
        {
            _yahooFinanceParser = new YahooFinanceParser();
        }

        [TearDown]
        public void Teardown()
        {
            _yahooFinanceParser = null;
        }

        [TestCase("VOD", "VOD", "NY")]
        [TestCase("VOD.L", "VOD", "L")]
        public void ShouldPopulatePriceObject(string epicCode, string expectedEpicCode, string expectedMarket)
        {
            //  Date,Open,High,Low,Close,Volume,Adj Close
            string line = "2016-01-04,219.50,220.074,215.375,216.00,73377400,216.00";

            var price = _yahooFinanceParser.Parse(epicCode, line);

            Assert.That(price, Is.Not.Null);
            Assert.That(price.Date, Is.EqualTo(new DateTime(2016, 01, 04)));
            Assert.That(price.Open, Is.EqualTo(219.50));
            Assert.That(price.High, Is.EqualTo(220.074));
            Assert.That(price.Low, Is.EqualTo(215.375));
            Assert.That(price.Close, Is.EqualTo(216.00));
            Assert.That(price.Volume, Is.EqualTo(73377400));
            Assert.That(price.AdjustedClose, Is.EqualTo(216.00));
            Assert.That(price.Epic, Is.EqualTo(expectedEpicCode));
            Assert.That(price.Market, Is.EqualTo(expectedMarket));
        }

        [TestCase("wrongformat,201.54,220.074,215.375,216.00,73377400,216.00")]
        [TestCase("2016-01-04,wrongformat,220.074,215.375,216.00,73377400,216.00")]
        [TestCase("2016-01-04,201.54,wrongformat,215.375,216.00,73377400,216.00")]
        [TestCase("2016-01-04,201.54,220.074,wrongformat,216.00,73377400,216.00")]
        [TestCase("2016-01-04,201.54,220.074,215.375,wrongformat,73377400,216.00")]
        [TestCase("2016-01-04,201.54,220.074,215.375,216.00,wrongformat,216.00")]
        [TestCase("2016-01-04,201.54,220.074,215.375,216.00,73377400,wrongformat")]
        public void ShouldRaiseExceptionIfValuesCannotBeConverted(string line)
        {
            string epic = "VOD.L";

            Assert.Throws<ApplicationException>(() => _yahooFinanceParser.Parse(epic, line));
        }
    }
}
