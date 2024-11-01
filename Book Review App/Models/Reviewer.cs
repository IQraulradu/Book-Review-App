namespace Book_Review_App.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Relationship 1-M with Review
        public ICollection<Review> Reviews { get; set; }
    }
}
