using ElasticSearchService.Converters;
using ElasticSearchService.Gateway;
using Models;

namespace ElasticSearchService.Indexers
{
    public class Indexer : IIndexer
    {
        private readonly IElasticSearchGateway _elasticSearchGateway;

        public Indexer(IElasticSearchGateway elasticSearchGateway)
        {
            _elasticSearchGateway = elasticSearchGateway;
        }

        public void Index(string indexName, string typeName, Price price)
        {
            var converter = new PriceToDocumentConverter();
            var document = converter.Convert(price);

            Index(indexName, typeName, document);
        }

        private void Index(string indexName, string typeName, string document)
        {
            _elasticSearchGateway.Save(indexName, typeName, document);
        }
    }
}
