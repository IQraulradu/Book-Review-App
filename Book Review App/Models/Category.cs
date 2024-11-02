namespace Book_Review_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationship M - M
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
