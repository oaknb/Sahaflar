using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sahaflar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahaflar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSellerController : ControllerBase
    {
        Sahafs _context;
        public BookSellerController(Sahafs context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("AddBookSeller")]
        public IActionResult AddBookSeller(BookSeller seller)
        {
            _context.BookSellers.Add(seller);
            _context.SaveChanges();

            return Ok(seller);
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpPost]
        [Route("RentABook")]
        public IActionResult RentABook(Rent rent)
        {
            Rent rents = _context.Rents.Where(a=>a.BookId==rent.BookId).OrderBy(a=>a.EndTime).FirstOrDefault();
            if(rents==null)
            {
                _context.Rents.Add(rent);
                _context.SaveChanges();

                return Ok(rent);
            }
            else
            {
                if (rents.EndTime < DateTime.Now)
                {
                    _context.Rents.Add(rent);
                    _context.SaveChanges();

                    return Ok(rent);
                }
                return BadRequest("Kitap Halen Kiralık");
            }
            
        }

        [HttpGet]
        [Route("GetRentDetail")]
        public IActionResult GetRentDetail(string date)
        {
            DateTime timeGap = Convert.ToDateTime(date);
            List<Rent> rents = _context.Rents.Where(a=>a.StartTime==timeGap).ToList();
           


            return Ok(rents.Count());
        }

    }
}
