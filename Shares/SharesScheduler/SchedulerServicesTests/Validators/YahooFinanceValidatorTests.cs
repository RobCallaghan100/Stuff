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
            var line = "Date,Open,High,Low,Close,Volume,Adj Close";

            var result = _yahooFinanceValidator.CheckHeaders(line);

            Assert.That(result.IsValid, Is.True);
            Assert.That(string.IsNullOrEmpty(result.Message), Is.True);
        }

        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "DateX,Open,High,Low,Close,Volume,Adj Close" )]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "Date,OpenX,High,Low,Close,Volume,Adj Close" )]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "Date,Open,HighX,Low,Close,Volume,Adj Close" )]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "Date,Open,High,LowX,Close,Volume,Adj Close" )]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "Date,Open,High,Low,CloseX,Volume,Adj Close" )]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "Date,Open,High,Low,Close,VolumeX,Adj Close" )]
        [TestCase(false, "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close", "Date,Open,High,Low,Close,Volume,Adj CloseX" )]
        public void ShouldCheckHeadersReturnValidIsFalseIfHeadersAreNotAsExpected(bool expectedValid, string expectedMessage, string line)
        {
            var result = _yahooFinanceValidator.CheckHeaders(line);

            Assert.That(result.IsValid, Is.EqualTo(expectedValid));
            Assert.That(result.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase(false, "Expecting 7 columns", "Date,Open,High,Low,Close,Volume,Adj Close,Extra Column" )]
        [TestCase(false, "Expecting 7 columns", "Date,Open,High,Low,Close,Volume" )]
        public void ShouldReturnValidAsFalseIfNot7Columns(bool expectedValid, string expectedMessage, string line)
        {
            var result = _yahooFinanceValidator.CheckHeaders(line);

            Assert.That(result.IsValid, Is.EqualTo(expectedValid));
            Assert.That(result.Message, Is.EqualTo("Expecting 7 columns"));
        }
    }
}