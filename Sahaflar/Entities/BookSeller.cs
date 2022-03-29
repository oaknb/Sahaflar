using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahaflar.Entities
{
    public class BookSeller
    {
        public int BookSellerId { get; set; }
        public string SellerName { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
