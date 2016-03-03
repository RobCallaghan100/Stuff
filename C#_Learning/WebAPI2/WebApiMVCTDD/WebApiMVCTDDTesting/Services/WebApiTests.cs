namespace WebApiMVCTDDTesting.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Results;
    using Moq;
    using NUnit.Framework;
    using WebApiMVCTDD.Controllers;
    using WebApiMVCTDD.Interfaces;
    using WebApiMVCTDD.Models;

    [TestFixture]
    public class WebApiTests
    {
        private BooksController _bookController;
        private Mock<IBooksRepository> _booksRepository;

        [SetUp]
        public void Setup()
        {
            _booksRepository = new Mock<IBooksRepository>();
            _bookController = new BooksController(_booksRepository.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _bookController = null;
            _booksRepository = null;
        }

        [Test]
        public void WhenGettingItShouldReturnAllBooks()
        {
            var expectedBooks = new List<Book>
            {
                new Book {Id=1, Name="Mock Book 1" },
                new Book {Id=2, Name="Mock Book 2" }
            };
            _booksRepository.Setup(r => r.GetBooks()).Returns(expectedBooks);

            var actionResult = _bookController.Get();

            var response = actionResult as OkNegotiatedContentResult<IEnumerable<Book>>;
            Assert.IsNotNull(response);
            var books = response.Content;
            Assert.That(books.Count(), Is.EqualTo(2));
        }

        [Test]
        public void WhenGettingWithAKnownIdItShouldReturnThatBook()
        {
            var expectedBook = new Book
            {
                Id=1,
                Name ="Mock Book 1"
            };
            _booksRepository.Setup(r => r.GetBook(It.IsAny<int>())).Returns(expectedBook);

            var result = _bookController.Get(1) as OkNegotiatedContentResult<Book>;

            Assert.That(result, Is.Not.Null);
            var returnedBook = result.Content as Book;
            Assert.That(returnedBook, Is.Not.Null);
            Assert.That(returnedBook.Id, Is.EqualTo(1));
            Assert.That(returnedBook.Name, Is.EqualTo("Mock Book 1"));
        }

        [Test]
        public void WhenGettingWithAnUnknownIdItShouldReturnNotFound()
        {
            _booksRepository.Setup(r => r.GetBook(It.IsAny<int>())).Returns((Book) null);

            var result = _bookController.Get(1) as NotFoundResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void WhenPuttingABookItShouldBeUpdated()
        {
            var book = new Book { Id = 1, Name = "Updated Name"};
            _booksRepository.Setup(r => r.Update(It.IsAny<Book>())).Returns(book);

            var result = _bookController.Put(1, book);

            var contentResult = result as OkNegotiatedContentResult<Book>;
            Assert.That(contentResult, Is.Not.Null);
            var updatedBook = contentResult.Content;
            Assert.That(updatedBook, Is.Not.Null);
            Assert.That(updatedBook.Id, Is.EqualTo(1));
            Assert.That(updatedBook.Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public void WhenPuttingABookThatIsNotValidReturnsBadRequest()
        {
            _bookController.ModelState.AddModelError("", "");

            var result = _bookController.Put(1, null);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<InvalidModelStateResult>());
        }

        [Test]
        public void WhenPostingABookItShouldBeAdded()
        {
            var book = new Book
            {
                Id = 4,
                Name = "A new book"
            };
            _booksRepository.Setup(r => r.AddBook(It.IsAny<Book>())).Returns(book);

            var actionResult = _bookController.Post(book);

            var response = actionResult as CreatedAtRouteNegotiatedContentResult<Book>;
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Content, Is.Not.Null);
            Assert.That("DefaultApi", Is.EqualTo(response.RouteName));
            Assert.That(response.Content.Id, Is.EqualTo(response.RouteValues["id"]));
        }
    }
}
