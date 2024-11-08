using AutoMapper;
using Book_Review_App.Data;
using Book_Review_App.Interface;
using Book_Review_App.Models;

namespace Book_Review_App.BookRepository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByLibrary(int libraryId)
        {
            return _context.Libraries.Where(l => l.Id == libraryId).Select(c => c.Country).FirstOrDefault();
        }


        public ICollection<Library> GetLibraryFromACountry(int countryId)
        {
            return _context.Libraries.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
