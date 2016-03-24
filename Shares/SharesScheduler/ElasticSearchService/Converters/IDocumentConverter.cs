namespace ElasticSearchService.Converters
{
    public interface IDocumentConverter<T>
    {
        string Convert(T value);
    }
}