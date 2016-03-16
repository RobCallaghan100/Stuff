namespace SchedulerServicesTests
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using SchedulerServices;

    [TestFixture]
    public class YahooFinanceClientTests
    {
        [Test]
        public async Task ShouldReturnPriceFromGet()
        {
            string epicCode = "VOD";
            var yahooFinanceClient = new YahooFinanceClient();

            var dateTime = new DateTime(2016, 1, 4);
            var price = await yahooFinanceClient.Get(epicCode, dateTime);

            Assert.That(price, Is.Not.Null);
            Assert.That(price.Epic, Is.EqualTo("VOD"));
            Assert.That(price.Open, Is.GreaterThan(0M));
            Assert.That(price.High, Is.GreaterThan(0M));
            Assert.That(price.Low, Is.GreaterThan(0M));
            Assert.That(price.Close, Is.GreaterThan(0M));
            Assert.That(price.Volume, Is.GreaterThan(0M));
            Assert.That(price.Market, Is.GreaterThan(0M));
        }

        // TODO: get back range of dates
    }
}
