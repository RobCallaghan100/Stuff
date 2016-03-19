using System.Security.Cryptography.X509Certificates;
using Models;
using Moq;
using SchedulerServices.Builders;

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
            string epicCode = "VOD.L";
            var mockQueryStringBuilder = new Mock<IQueryStringBuilder>();
            mockQueryStringBuilder.Setup(qsb => qsb.BuildQueryString(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns("table.csv?s=VOD.L&a=0&b=4&c=2016&d=0&e=4&f=2016&g=d");
            var yahooFinanceClient = new YahooFinanceClient(mockQueryStringBuilder.Object);

            var dateTime = new DateTime(2016, 1, 4);
            var price = await yahooFinanceClient.Get(epicCode, dateTime);

            Assert.That(price, Is.Not.Null);
            Assert.That(price.Epic, Is.EqualTo("VOD.L"));
            Assert.That(price.Date, Is.EqualTo(new DateTime(2016, 1, 4)));
            Assert.That(price.Open, Is.GreaterThan(0M));
            Assert.That(price.High, Is.GreaterThan(0M));
            Assert.That(price.Low, Is.GreaterThan(0M));
            Assert.That(price.Close, Is.GreaterThan(0M));
            Assert.That(price.Volume, Is.GreaterThan(0M));
            Assert.That(price.Market, Is.EqualTo("L")); 
        }

        [Test]
        public async Task ShouldRaiseExceptionFromGetIfCannotRespondFromEndpoint()
        {
            string epicCode = "VOD.L";
            var mockQueryStringBuilder = new Mock<IQueryStringBuilder>();
            var yahooFinanceClient = new YahooFinanceClient(mockQueryStringBuilder.Object)
            {
                BaseAddress = new Uri("http://real-chart.finance.yyahoo.com")
            };

            var dateTime = new DateTime(2016, 1, 4);

            Assert.That(async () => await yahooFinanceClient.Get(epicCode, dateTime), Throws.TypeOf<ApplicationException>());
        }

        // TODO: get back range of dates
    }
}
