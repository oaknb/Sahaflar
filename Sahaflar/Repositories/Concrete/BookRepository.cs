using Sahaflar.Entities;
using Sahaflar.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Sahaflar.Repositories.Concrete
{
    public class BookRepository : IBookRepository
    {
        private Sahafs context;
        public BookRepository(Sahafs context)
        {
            this.context = context;
        }
        public bool AddBook(Books book)
        {
           
               context.Books.Add(book);

               return context.SaveChanges()>0;

        }

        public Books GetBookById(int id)
        {
            

                Books book = context.Books.Where(x => x.BooksId == id).SingleOrDefault();

                return book;
            
        }

        public List<Books> GetBooks()
        {

            return context.Books.ToList();

        }
    }
}
