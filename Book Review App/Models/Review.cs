namespace Book_Review_App.Models
{
    public class Review
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Text { get; set; }

        //Relationship with Book
        public int BookId { get; set; }
        public Book Book { get; set; }

        //Relationship with Reviewer
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
