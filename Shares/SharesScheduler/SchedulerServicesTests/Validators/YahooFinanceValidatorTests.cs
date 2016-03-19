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
    }
}