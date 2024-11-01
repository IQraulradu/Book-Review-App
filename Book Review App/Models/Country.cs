namespace Book_Review_App.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationship 1-M with Library
        public ICollection<Library> Libraries { get; set; }
    }
}
