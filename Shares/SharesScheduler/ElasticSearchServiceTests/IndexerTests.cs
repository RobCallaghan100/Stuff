using ElasticSearchService.Gateway;
using ElasticSearchService.Indexers;
using Models;
using Moq;
using NUnit.Framework;

namespace ElasticSearchServiceTests
{
    [TestFixture]
    public class IndexerTests
    {
        [Test]
        public void ShouldIndexPrice()
        {
            var mockGateway = new Mock<IElasticSearchGateway>();
            var indexer = new Indexer(mockGateway.Object);

            var price = new Price
            {
                Epic = "VOD.L"
            };
            indexer.Index("AnIndex", "AType", price);

            mockGateway.Verify(g => g.Save(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
