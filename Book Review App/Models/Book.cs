using Book_Review_App.Models.UserManagment;

namespace Book_Review_App.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        // Relationship M-M with Category through BookCategory
        public ICollection<BookCategory> BookCategories { get; set; }
        // Relationship M-M with Library through BookLibrary
        public ICollection<BookLibrary> BookLibraries { get; set; } 
        // Relationship 1-M with Review
        public ICollection<Review> Reviews { get; set; }

        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }


    }
}
