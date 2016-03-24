using System;
using ElasticSearchService.Converters;
using Models;
using NUnit.Framework;

namespace ElasticSearchServiceTests.Converters
{
    [TestFixture]
    public class PriceToDocumentConverterTest
    {
        [Test]
        public void ShouldConvertPriceToJsonDocument()
        {
            var expectedOutput = @"{""doc"":{""Market"":""L"",""Epic"":""VOD.L"",""Date"":""2016-10-14T00:00:00"",""Open"":200.21,""High"":210.67,""Low"":197.69,""Close"":199.78,""Volume"":1223244.0,""AdjustedClose"":199.77}}";

            var price = GetPrice();
            var priceToDocumentConverter = new PriceToDocumentConverter();

            var document = priceToDocumentConverter.Convert(price);

            Assert.That(document, Is.Not.Null);
            Assert.That(document, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ShouldRaiseExceptionIfPriceIsNull()
        {
            var priceToDocumentConverter = new PriceToDocumentConverter();

            var ex = Assert.Throws<ApplicationException>(() => priceToDocumentConverter.Convert(null));

            Assert.That(ex.Message, Is.EqualTo("Price value should not be null"));
        }
        
        private static Price GetPrice()
        {
            var price = new Price
            {
                Epic = "VOD.L",
                Market = "L",
                Open = 200.21M,
                High = 210.67M,
                Low = 197.69M,
                Close = 199.78M,
                AdjustedClose = 199.77M,
                Volume = 1223244,
                Date = new DateTime(2016, 10, 14)
            };
            return price;
        }
        
    }
}
