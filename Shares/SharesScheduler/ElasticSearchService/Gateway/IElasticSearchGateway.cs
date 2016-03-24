namespace ElasticSearchService.Gateway
{
    public interface IElasticSearchGateway
    {
        void Save(string indexName, string typeName, string document);
    }
}   