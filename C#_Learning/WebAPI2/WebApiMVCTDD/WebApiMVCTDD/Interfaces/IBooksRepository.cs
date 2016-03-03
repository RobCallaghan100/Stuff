namespace WebApiMVCTDD.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book Update(Book book);
        Book AddBook(Book book);
    }
}