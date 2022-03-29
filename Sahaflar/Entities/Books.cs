using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahaflar.Entities
{
    public class Books
    {
        public int BooksId { get; set; }
        public string BookName { get; set; }
        
        public BookSeller BookSeller { get; set; }
        public int BookSellerId { get; set; }
    }
}
