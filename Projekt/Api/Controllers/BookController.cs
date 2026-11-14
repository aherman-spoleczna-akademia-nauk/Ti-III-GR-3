using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks([FromQuery] string? title)
        {
            var books = _bookService.GetBooks(title);
            if (books.Count == 0)
                return NoContent();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookCommand command)
        {
            var result = _bookService.AddNewBook(command);
            if (result.Success)
                return Created();
            else
                return BadRequest(result.Error);
        }

    }
}
