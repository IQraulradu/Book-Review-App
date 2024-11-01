namespace Book_Review_App.Models
{
    public class Library
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }

        // Relationship with Country
        public int CountryId { get; set; }
        public Country Country { get; set; }

        // Relationship M - M Book through BookLibrary
        public ICollection<Library> BookLibraries { get; set; }
    }
}
