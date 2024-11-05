using Microsoft.AspNetCore.Mvc;
using Book_Review_App.Interface;
using Book_Review_App.Models;

namespace Book_Review_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();

            return Ok(books);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            if(book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetBookByName(string name)
        {
            var book = _bookRepository.GetBook(name);
            if(book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("{id}/rating")]
        public IActionResult GetBookRating(int id)
        {
            if(!_bookRepository.BookExists(id))
                return NotFound();
            var rating = _bookRepository.GetBookRating(id);

            return Ok(rating);
        }

    }
}
