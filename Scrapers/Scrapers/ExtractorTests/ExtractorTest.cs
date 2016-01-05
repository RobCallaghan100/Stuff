namespace ExtractorTests
{
    using System.Linq;
    using System.Net.Http;
    using Extractor;
    using NUnit.Framework;

    [TestFixture]
    public class ExtractorTest
    {
        /*

            goes to site url and check its is ok
            goes to site url and it is bad

            gets number of pages to loop through

            click on link

            return data



        */  


        [Test]
        public void ShouldGetCountOfPages()
        {
            var extractor = new Extractor();

            var pageCount = extractor.GetPageCount();

            Assert.That(pageCount, Is.EqualTo(10));
        }
        
        [Test]
        public void ShouldGetListOfLinksOnPage()
        {
            var extractor = new Extractor();

            var pageLinks = extractor.GetPageLinks();

            Assert.That(pageLinks.Count(), Is.EqualTo(5));
        }
    }
}
