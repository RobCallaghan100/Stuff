namespace WebApiMVCTDDTesting.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using BooksClient;
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void WhenGettingAllBooksTheyShouldBeReturned()
        {
            var books = new List<Book>
            {
                new Book {Id = 1, Author = "Me", Name = "Book 1"},
                new Book {Id = 2, Author = "You", Name = "Book 2"},
            };

            var testingHandler = new TestingDelegatingHandler<IEnumerable<Book>>(books);
            var server =new HttpServer(new HttpConfiguration(), testingHandler);
            var client = new BooksClient(new HttpClient(server));

            var booksReturned = client.GetBooks();

            Assert.AreEqual(2, booksReturned.Count());
        }

        [Test]
        public void WhenGettingAValidBookItShouldBeReturned()
        {
            var book = new Book
            {
                Id = 1, Author = "Me", Name = "Book 1"
            };

            var testingHandler = new TestingDelegatingHandler<Book>(book);
            var server = new HttpServer(new HttpConfiguration(), testingHandler);
            var client = new BooksClient(new HttpClient(server));

            var bookReturned = client.GetBook(1);

            Assert.AreEqual(1, bookReturned.Id);
        }   
    }

    public class TestingDelegatingHandler<T> : DelegatingHandler
    {
        private Func<HttpRequestMessage, HttpResponseMessage> _httpResponseMessageFunc; 

        public TestingDelegatingHandler(T value) :this(HttpStatusCode.OK, value)
        {
        }

        public TestingDelegatingHandler(HttpStatusCode statusCode) :this(statusCode, default(T))
        {
        }

        public TestingDelegatingHandler(HttpStatusCode statusCode, T value)
        {
            _httpResponseMessageFunc = r => r.CreateResponse(statusCode);
        }

        public TestingDelegatingHandler(Func<HttpRequestMessage, HttpResponseMessage> httpResponseMessageFunc)
        {
            _httpResponseMessageFunc = httpResponseMessageFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _httpResponseMessageFunc(request));
        }
    }

}
