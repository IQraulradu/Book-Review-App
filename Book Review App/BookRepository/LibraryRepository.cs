using AutoMapper;
using Book_Review_App.Data;
using Book_Review_App.Interface;
using Book_Review_App.Models;

namespace Book_Review_App.BookRepository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LibraryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Library GetLibrary(int libraryId)
        {
            return _context.Libraries.Where(l => l.Id == libraryId).FirstOrDefault();
        }

        public ICollection<Library> GetLibraryWithBook(int bookId)
        {
            return _context.BookLibraries.Where(b => b.Book.Id == bookId).Select(b => b.Library).ToList();
        }


        public ICollection<Library> GetLibraries()
        {
            return _context.Libraries.ToList();
        }

        public ICollection<Book> GetBookFromLibrary(int libraryId)
        {
            return _context.BookLibraries.Where(b => b.Library.Id == libraryId).Select(b => b.Book).ToList();
        }

        public bool LibraryExists(int libraryId)
        {
            return _context.Libraries.Any(l => l.Id == libraryId);
        }
    }
}
