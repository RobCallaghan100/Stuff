using System.Linq;
using System.Web.Http;

namespace WebApiMVCTDD.Controllers
{
    using global::Models;
    using Interfaces;
    using Models;

    public class BooksController : ApiController
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_booksRepository.GetBooks().AsEnumerable());
        }

        public IHttpActionResult Get(int id)
        {
            var book = _booksRepository.GetBook(id);

            if (book == null)
            {   
                return NotFound();
            }

            return Ok(book);
        }

        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_booksRepository.Update(book));
        }

        public IHttpActionResult Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = _booksRepository.AddBook(book);

            return CreatedAtRoute("DefaultApi", new {book.Id}, newBook);
        }
    }
}
