using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sahaflar.Entities;
using Sahaflar.Models;
using Sahaflar.Repositories.Abstract;
using System.Collections.Generic;

namespace Sahaflar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(Books book)
        {
            bool result = bookRepository.AddBook(book);
            if (result)
            {
                return Ok(new ResultModel { State = "Succeed", Message = "Book created successfully" });
            }

            return BadRequest(new ResultModel { State = "Warning", Message = "Book could not create." });
        }

        [HttpGet]
        [Route("GetBooks")]
        public IActionResult GetBooks()
        {
            List<Books> books = bookRepository.GetBooks();
            if (books != null)
            {
                return Ok(books);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Any books cannot be found" });

        }

        [HttpGet]
        [Route("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            Books book = bookRepository.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Book cannot be found" });

        }
    }
}
