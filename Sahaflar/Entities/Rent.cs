using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahaflar.Entities
{
    public class Rent
    {
        public int RentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Books Books { get; set; }
        public int BooksId { get; set; }
    }
}
