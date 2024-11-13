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
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public LibraryController(ILibraryRepository libraryRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _countryRepository = countryRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLibrary([FromQuery] int countryId, [FromBody] LibraryDto libraryCreate)
        {
            if (libraryCreate == null)
                return BadRequest(ModelState);

            var library = _libraryRepository.GetLibraries().Where(l => l.Name.Trim().ToUpper() == libraryCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (library != null)
            {
                ModelState.AddModelError("", "Library already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var libraryMap = _mapper.Map<Library>(libraryCreate);
            libraryMap.CountryId = countryId;

            if (!_libraryRepository.CreateLibrary(libraryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
