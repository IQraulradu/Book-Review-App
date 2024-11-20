namespace Book_Review_App.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public int bookId { get; set; }
        public int reviewerId { get; set; }
    }
}
