using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ElasticSearchService.Gateway;
using NUnit.Framework;

namespace ElasticSearchServiceTests.Gateway
{
    [TestFixture]
    public class ElasticSearchGatewayTests
    {
        private const string BaseURI = "http://localhost:9200";

        [Test]
        public async Task ShouldSaveDocument()
        {
            const string IndexName = "testindex";
            const string TypeName = "TestType";

            var document = @"{""doc"":{""Market"":""L"",""Epic"":""VOD.L"",""Date"":""2016-10-14T00:00:00"",""Open"":200.21,""High"":210.67,""Low"":197.69,""Close"":199.78,""Volume"":1223244.0,""AdjustedClose"":199.77}}";

            await RemoveIndex(IndexName); // belts and braces
            await CreateIndex(IndexName, document);

            var elasticSearchGateway = new ElasticSearchGateway();


            //            get json document
            // elasticSearchGateway.Save(IndexName, TypeName, document);

            //            do a rough search on elasticsearch
            //            assert that we have the expected document in ES

            await RemoveIndex(IndexName);
        }

        private async Task RemoveIndex(string indexName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                var response = await client.DeleteAsync($"{indexName}");
            }
        }

        private async Task CreateIndex(string indexName, string document)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                var httpContent = new StringContent(document, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{indexName}", httpContent);

                if (!response.IsSuccessStatusCode)
                {
                   throw new AssertionException("Problem with creating index");
                }
            }
        }
        
    }
}
