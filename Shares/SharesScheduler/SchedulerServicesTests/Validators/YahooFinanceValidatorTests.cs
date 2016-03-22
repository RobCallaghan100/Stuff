using NUnit.Framework;
using SchedulerServices.Validators;

namespace SchedulerServicesTests.Validators
{
    [TestFixture]
    public class YahooFinanceValidatorTests
    {
        private YahooFinanceValidator _yahooFinanceValidator;

        [SetUp]
        public void Setup()
        {
            _yahooFinanceValidator = new YahooFinanceValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _yahooFinanceValidator = null;
        }

        [Test]
        public void ShouldCheckHeadersReturnValidIfHeadersAreAsExpected()
        {
            var line = new[] {"Date", "Open", "High", "Low", "Close", "Volume", "Adj Close"};

            var result = _yahooFinanceValidator.CheckHeaders(line);

            Assert.That(result.IsValid, Is.True);
            Assert.That(string.IsNullOrEmpty(result.Message), Is.True);
        }

        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "DateX", "Open", "High", "Low", "Close", "Volume", "Adj Close" })]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "Date", "OpenX", "High", "Low", "Close", "Volume", "Adj Close" })]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "Date", "Open", "HighX", "Low", "Close", "Volume", "Adj Close" })]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "Date", "Open", "High", "LowX", "Close", "Volume", "Adj Close" })]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "Date", "Open", "High", "Low", "CloseX", "Volume", "Adj Close" })]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "Date", "Open", "High", "Low", "Close", "VolumeX", "Adj Close" })]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", new[] { "Date", "Open", "High", "Low", "Close", "Volume", "Adj CloseX" })]
        public void ShouldCheckHeadersReturnValidIsFalseIfHeadersAreNotAsExpected(bool expectedValid, string expectedMessage, string[] line)
        {
            var result = _yahooFinanceValidator.CheckHeaders(line);

            Assert.That(result.IsValid, Is.EqualTo(expectedValid));
            Assert.That(result.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void ShouldReturnValidAsFalseIfNot7Columns()
        {
            Assert.IsFalse(true);
        }
    }
}