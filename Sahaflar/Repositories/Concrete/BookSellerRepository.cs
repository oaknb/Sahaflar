using Sahaflar.Entities;
using Sahaflar.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Sahaflar.Repositories.Concrete
{
    public class BookSellerRepository : IBookSellerRepository
    {
        private Sahafs context;
        public BookSellerRepository(Sahafs context)
        {
            this.context = context;
        }
        public bool AddBookSeller(BookSeller bookSeller)
        {
            context.BookSellers.Add(bookSeller);

            return context.SaveChanges() > 0;
        }

        public BookSeller GetBookSellerById(int id)
        {
            BookSeller bookSeller = context.BookSellers.Where(x => x.BookSellerId == id).SingleOrDefault();

            return bookSeller;
        }

        public List<BookSeller> GetBookSellers()
        {
            return context.BookSellers.ToList();
        }
    }
}
