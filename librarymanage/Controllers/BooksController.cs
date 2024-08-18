using librarymanage.Models;
using librarymanage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace librarymanage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksServices _booksServices;

        public BooksController(BooksServices booksServices)
        {
            _booksServices = booksServices;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _booksServices.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var book = _booksServices.GetBookById(id);
            if (book == null) { return NotFound(); }
            else
            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook( Books book)
        {
            _booksServices.AddBook(book);
            return CreatedAtAction(nameof(GetId), new {id = book.Id}, book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,  Books book)
        {
            _booksServices.UpdateBook(id, book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksServices.DeleteBook(id);
            return NoContent();
        }
    }
}
