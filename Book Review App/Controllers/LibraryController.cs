using AutoMapper;
using Book_Review_App.DTO;
using Book_Review_App.Interface;
using Book_Review_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Review_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        public LibraryController(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library>))]
        public IActionResult GetLibraries()
        {
            var libraries = _mapper.Map<List<LibraryDto>>(_libraryRepository.GetLibraries());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(libraries);
        }

        [HttpGet("{libraryId}")]
        [ProducesResponseType(200, Type = typeof(Library))]
        [ProducesResponseType(400)]
        public IActionResult GetLibrary(int libraryId)
        {
            if(!_libraryRepository.LibraryExists(libraryId))
                return NotFound();

            var library = _mapper.Map<LibraryDto>(_libraryRepository.GetLibrary(libraryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(library);
        }

        [HttpGet("{libraryId}/book")]
        [ProducesResponseType(200, Type = typeof(Library))]
        public IActionResult GetBookFromLibrary(int libraryId) 
        {
            if (!_libraryRepository.LibraryExists(libraryId))
            {
                return NotFound();
            }

            var library = _mapper.Map<List<BookDto>>(_libraryRepository.GetBookFromLibrary(libraryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(library);
        }
    }
}
