using System;
using NUnit.Framework;
using SchedulerServices.Builders;

namespace SchedulerServicesTests.Builders
{
    [TestFixture]
    public class YahooQueryStringBuilderTests
    {
        [Test]
        public void ShouldBuildQueryStringGivenEpicAndDateTime()
        {
            var yahooQueryStringBuilder = new YahooQueryStringBuilder();

            var queryString = yahooQueryStringBuilder.BuildQueryString("VOD.L", new DateTime(2016, 2, 27));

            Assert.That(queryString, Is.EqualTo("table.csv?s=VOD.L&a=1&b=27&c=2016&d=1&e=27&f=2016&g=d"));
        }

        [Test]
        public void ShouldBuildQueryStringGivenEpicAndFromDateAndToDate()
        {
            var yahooQueryStringBuilder = new YahooQueryStringBuilder();

            var queryString = yahooQueryStringBuilder.BuildQueryString("VOD.L", new DateTime(2015, 11, 13), new DateTime(2015, 12, 31));

            Assert.That(queryString, Is.EqualTo("table.csv?s=VOD.L&a=10&b=13&c=2015&d=11&e=31&f=2015&g=d"));
        }
    }
}
