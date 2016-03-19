using NUnit.Framework;
using SchedulerServices.Validators;

namespace SchedulerServicesTests.Validators
{
    [TestFixture]
    public class YahooFinanceValidatorTests
    {
        [Test]
        public void ShouldCheckHeadersReturnValidIfHeadersAreAsExpected()
        {
            var line = new[] {"Date", "Open", "High", "Low", "Close", "Volume", "Adj Close"};
            var yahooFinanceValidator = new YahooFinanceValidator();

            var result = yahooFinanceValidator.CheckHeaders(line);

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
            var yahooFinanceValidator = new YahooFinanceValidator();

            var result = yahooFinanceValidator.CheckHeaders(line);

            Assert.That(result.IsValid, Is.EqualTo(expectedValid));
            Assert.That(result.Message, Is.EqualTo(expectedMessage));
        }

         todo: add test with wrong number of columns, should be 7
         todo: then do parser in YahooFinanceClient and their associated tests
    }
}