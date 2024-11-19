using Book_Review_App.Models;

namespace Book_Review_App.Interface
{
    public interface ILibraryRepository
    {
        ICollection<Library> GetLibraries();
        Library GetLibrary(int libraryId);
        ICollection<Library> GetLibraryWithBook(int bookId);
        ICollection<Book> GetBookFromLibrary(int libraryId);
        bool LibraryExists(int libraryId);
        bool CreateLibrary(Library library);
        bool UpdateLibrary(Library library);
        bool Save();

    }
}
