namespace SharesSchedulerTests.Integration
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class IntegrationTests
    {
        // http://simoneb.github.io/blog/2013/01/19/async-support-in-nunit/

        [Test]
        public async Task ShouldGetDataFromElasticSearchAfterPopulatingFromCallToYahooFinance()
        {
            string jsonResult = "";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:9200/shares/_search");
                if (!response.IsSuccessStatusCode)
                {
                    Assert.Fail("Response is incorrect");
                }

                jsonResult = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonResult))
                {
                    Assert.Fail("Result is in wrong format");
                    // TODO: De-serialise
                }
            }

            Assert.That(jsonResult.Contains("VOD"));

            /*
            go to yahoo finance
            get data for vod
            populate elastic search
            */
        }
    }
}
