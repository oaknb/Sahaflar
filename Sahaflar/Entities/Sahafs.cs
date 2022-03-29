using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sahaflar.Entities
{
    public class Sahafs :DbContext

    {
        public Sahafs(DbContextOptions<Sahafs> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookSeller> BookSellers { get; set; }


    }
}
