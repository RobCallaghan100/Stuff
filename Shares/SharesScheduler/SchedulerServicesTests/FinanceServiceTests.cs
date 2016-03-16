namespace SchedulerServicesTests
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using Moq;
    using NUnit.Framework;
    using SchedulerServices;

    [TestFixture]
    public class FinanceServiceTests
    {
        [Test]
        public async void ShouldGetLatestPrice()
        {
            var mockYahooClient = new Mock<IFinanceClient>();
            mockYahooClient.Setup(yc => yc.Get(It.IsAny<string>(), It.IsAny<DateTime>())).ReturnsAsync(GetPrice());
            var financeService = new FinanceService(mockYahooClient.Object);

            var price = await financeService.Get("VOD", new DateTime(2016, 01, 04));

            Assert.That(price, Is.Not.Null);
            Assert.That(price.Epic, Is.EqualTo("VOD"));
            Assert.That(price.Market, Is.EqualTo("FTSE"));
            Assert.That(price.Open, Is.EqualTo(143.53m));
            Assert.That(price.High, Is.EqualTo(154.23m));
            Assert.That(price.Low, Is.EqualTo(119.97m));
            Assert.That(price.Close, Is.EqualTo(123.1M));
            Assert.That(price.Volume, Is.EqualTo(36236732M));
        }

        private Price GetPrice()
        {
            return new Price
            {
                Market = "FTSE",
                Epic = "VOD",
                Open = 143.53M,
                High = 154.23M,
                Low = 119.97M,
                Close = 123.1M,
                Volume = 36236732M
            };
        }
    }
}
