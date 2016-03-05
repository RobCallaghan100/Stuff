namespace WebApiMVCTDD.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using global::Models;
    using Interfaces;
    using Models;

    public class BooksRepository : IBooksRepository
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "Book A" },
            new Book { Id = 2, Name = "Book B" },
            new Book { Id = 3, Name = "Book C" }
        };

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book Update(Book book)   
        {
            var selectedBook = _books.FirstOrDefault(b => b.Id == book.Id);
            selectedBook = book;

            return selectedBook;
        }

        public Book AddBook(Book book)
        {
            book.Id = 4; // hardcoded

            return book;
        }
    }
}