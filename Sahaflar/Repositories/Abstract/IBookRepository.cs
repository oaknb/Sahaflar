using Sahaflar.Entities;
using System.Collections.Generic;

namespace Sahaflar.Repositories.Abstract
{
    public interface IBookRepository
    {
        bool AddBook(Books book);
        List<Books> GetBooks();

        Books GetBookById(int id);
    }
}
