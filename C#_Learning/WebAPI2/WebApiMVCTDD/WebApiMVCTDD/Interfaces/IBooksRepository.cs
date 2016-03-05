namespace WebApiMVCTDD.Interfaces
{
    using System.Collections.Generic;
    using global::Models;
    using Models;

    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book Update(Book book);
        Book AddBook(Book book);
    }
}