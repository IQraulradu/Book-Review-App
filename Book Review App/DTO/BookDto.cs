using Book_Review_App.Models;

namespace Book_Review_App.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
 
    }
}
