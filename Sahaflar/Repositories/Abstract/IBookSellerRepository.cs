using Sahaflar.Entities;
using System.Collections.Generic;

namespace Sahaflar.Repositories.Abstract
{
    public interface IBookSellerRepository
    {
        bool AddBookSeller(BookSeller bookSeller);
        List<BookSeller> GetBookSellers();

        BookSeller GetBookSellerById(int id);
    }
}
