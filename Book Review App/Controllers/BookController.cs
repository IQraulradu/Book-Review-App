using Microsoft.AspNetCore.Mvc;
using Book_Review_App.Interface;
using Book_Review_App.Models;
using AutoMapper;
using Book_Review_App.DTO;

namespace Book_Review_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper, IReviewRepository reviewRepository)
        {
            _bookRepository = bookRepository;
            _reviewRepository = reviewRepository;
       
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var book = _mapper.Map<BookDto>(_bookRepository.GetBook(bookId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(book);
        }

       /* [HttpGet("{name}/name")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        public IActionResult GetBookByName(string name)
        {
            var book = _bookRepository.GetBook(name);

            if(book == null)
                return NotFound();

            var bookDto = _mapper.Map<BookDto>(book);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(bookDto);
        }*/


        [HttpGet("{bookId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetBookRating(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var rating = _bookRepository.GetBookRating(bookId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int libraryId, [FromQuery] int categoryId, [FromBody] BookDto bookCreate)
        {
            if (bookCreate == null)
                return BadRequest(ModelState);

            var books = _bookRepository.GetBooks().Where(c => c.Name.Trim().ToUpper() == bookCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (books != null)
            {
                ModelState.AddModelError("", "Book already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookMap = _mapper.Map<Book>(bookCreate);


            if (!_bookRepository.CreateBook(libraryId, categoryId, bookMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpPut("bookId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int bookId, [FromQuery] int libraryId, [FromQuery] int categoryId, [FromBody] BookDto updateBook)
        {
            if (updateBook == null)
                return BadRequest(ModelState);

            if (bookId != updateBook.Id)
                return BadRequest(ModelState);

            if(!_bookRepository.BookExists(bookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookMap = _mapper.Map<Book>(updateBook);

            if (!_bookRepository.UpdateBook(libraryId, categoryId, bookMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
                    
            }

            return NoContent();
        }

        [HttpDelete("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            var bookToDelete = _bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_bookRepository.DeleteBook(bookToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting book");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }





    }
}
