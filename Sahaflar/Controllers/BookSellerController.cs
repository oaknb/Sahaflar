using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sahaflar.Entities;
using Sahaflar.Models;
using Sahaflar.Repositories.Abstract;
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
        private readonly IBookSellerRepository bookSellerRepository;
        public BookSellerController(IBookSellerRepository bookSellerRepository)
        {
            this.bookSellerRepository = bookSellerRepository;
        }

        [HttpPost]
        [Route("AddBookSeller")]
        public IActionResult AddBookSeller(BookSeller seller)
        {
            bool result = bookSellerRepository.AddBookSeller(seller);
            if (result)
            {
                return Ok(new ResultModel { State = "Succeed", Message = "BookSeller created successfully" });
            }

            return BadRequest(new ResultModel { State = "Warning", Message = "BookSeller could not create" });
        }

        [HttpGet]
        [Route("GetBookSellers")]
        public IActionResult GetBookSellers()
        {
            List<BookSeller> bookSellers = bookSellerRepository.GetBookSellers();
            if (bookSellers != null)
            {
                return Ok(bookSellers);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Any bookSeller cannot be found" });

        }

        [HttpGet]
        [Route("GetBookSellerById")]
        public IActionResult GetBookSellerById(int id)
        {
            BookSeller bookSeller = bookSellerRepository.GetBookSellerById(id);
            if (bookSeller != null)
            {
                return Ok(bookSeller);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "BookSeller cannot be found" });

        }








    }
}
