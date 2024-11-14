using Book_Review_App.Data;
using Book_Review_App.Interface;
using Book_Review_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Review_App.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

/*        public Book GetBook(string name)
        {
            return _context.Books.FirstOrDefault(b => b.Name == name);
        }*/

        public decimal GetBookRating(int bookId)
        {
            var reviews = _context.Reviews.Where(r => r.Book.Id == bookId);

            if (!reviews.Any())
                return 0;

            return (decimal)reviews.Sum(r => r.Rating)/reviews.Count();
        }

        public bool BookExists(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }

        public bool CreateBook(int libraryId, int categoryId, Book book)
        {
            var bookLibraryEntity = _context.Libraries.Where(l => l.Id == libraryId).FirstOrDefault();
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var bookLibrary = new BookLibrary()
            {
                Library = bookLibraryEntity,
                Book = book,
            };
            _context.Add(bookLibrary);

            var bookCategory = new BookCategory()
            {
                Category = category,
                Book = book,
            };
            _context.Add(bookCategory);
            _context.Add(book);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
