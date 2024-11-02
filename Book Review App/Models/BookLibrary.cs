namespace Book_Review_App.Models
{
    public class BookLibrary
    {

        public int BookId { get; set; }
        public int LibraryId { get; set; }

        public Book Book { get; set; }
        public Library Library { get; set; } 
    }
}
