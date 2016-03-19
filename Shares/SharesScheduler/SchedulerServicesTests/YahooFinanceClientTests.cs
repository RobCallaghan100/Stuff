using Moq;
using SchedulerServices.Builders;
using SchedulerServices.Messages;
using SchedulerServices.Validators;

namespace SchedulerServicesTests
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using SchedulerServices;

    [TestFixture]
    public class YahooFinanceClientTests
    {
        private Mock<IQueryStringBuilder> _mockQueryStringBuilder;
        private Mock<IValidator> _mockYahooFinanceValidator;
        private YahooFinanceClient _yahooFinanceClient;

        [SetUp]
        public void Setup()
        {
            _mockQueryStringBuilder = new Mock<IQueryStringBuilder>();
            _mockYahooFinanceValidator = new Mock<IValidator>();

            _yahooFinanceClient = new YahooFinanceClient(_mockQueryStringBuilder.Object, _mockYahooFinanceValidator.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockQueryStringBuilder = null;

            _yahooFinanceClient.Dispose();
            _yahooFinanceClient = null;
        }

        [Test]
        public async Task ShouldReturnPriceFromGet()
        {
            string epicCode = "VOD.L";
            _mockQueryStringBuilder.Setup(qsb => qsb.BuildQueryString(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(GetQueryStringValue());
            _mockYahooFinanceValidator.Setup(yfv => yfv.CheckHeaders(It.IsAny<string[]>()))
                .Returns(new Validation {IsValid = true});

            var dateTime = new DateTime(2016, 1, 4);
            var price = await _yahooFinanceClient.Get(epicCode, dateTime);

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
            _yahooFinanceClient.BaseAddress = new Uri("http://real-chart.finance.yyahoo.com");
            var dateTime = new DateTime(2016, 1, 4);

            Assert.That(async () => await _yahooFinanceClient.Get(epicCode, dateTime), Throws.TypeOf<ApplicationException>());
        }

        [Test]
        public async Task ShouldThrowExceptionIfHeadersNotValid()
        {
            string epicCode = "VOD.L";
            _yahooFinanceClient.BaseAddress = new Uri("http://real-chart.finance.yahoo.com");
            var validation = new Validation {IsValid = false};
            _mockQueryStringBuilder.Setup(qsb => qsb.BuildQueryString(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(GetQueryStringValue());
            _mockYahooFinanceValidator.Setup(yfv => yfv.CheckHeaders(It.IsAny<string[]>())).Returns(validation);
            var dateTime = new DateTime(2016, 1, 4);

            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await _yahooFinanceClient.Get(epicCode, dateTime));

            Assert.That(ex.Message, Is.EqualTo("Problem calling yahoo finance"));
            Assert.That(ex.InnerException.Message, Is.EqualTo("Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close"));
        }

        // TODO: get back range of dates

        private static string GetQueryStringValue()
        {
            return "table.csv?s=VOD.L&a=0&b=4&c=2016&d=0&e=4&f=2016&g=d";
        }
    }
}
