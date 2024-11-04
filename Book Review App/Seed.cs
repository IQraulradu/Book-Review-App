using Book_Review_App.Data;
using Book_Review_App.Models;

namespace Book_Review_App
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            _dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Books.Any())
            {
                //Countries
                var usa = new Country { Name = "United States" };
                var uk = new Country { Name = "United Kingdom" };
                _dataContext.Countries.AddRange(usa, uk);

                //Add Categories
                var classic = new Category { Name = "Classic" };
                var fiction = new Category { Name = "Fiction" };
                var dystopian = new Category { Name = "Dystopian" };
                _dataContext.Categories.AddRange(classic, fiction, dystopian);

                //Add reviewers
                var reviewer1 = new Reviewer { FirstName = "John", LastName = "Doe" };
                var reviewer2 = new Reviewer { FirstName = "Jane", LastName = "Smith" };
                var reviewer3 = new Reviewer { FirstName = "Alex", LastName = "Johnson" };
                _dataContext.Reviewers.AddRange(reviewer1, reviewer2, reviewer3);

                //Add Books
                var book1 = new Book
                {
                    Name = "The Great Gatsby",
                    PublicationDate = new DateTime(1925, 4, 10),
                    BookCategories = new List<BookCategory>
                    {
                        new BookCategory {Category = classic },
                        new BookCategory {Category = fiction}
                    },
                    Reviews = new List<Review>
                    {
                        new Review {Title = "A Masterpice", Text = "An insightful look at the American Dream.", Reviewer = reviewer1 },
                        new Review {Title = "Overrated", Text = "Didn't live up to the hype.", Reviewer = reviewer2 }

                    }
                };

                var book2 = new Book
                {
                    Name = "1984",
                    PublicationDate = new DateTime(1949, 6, 8),
                    BookCategories = new List<BookCategory>
                    {
                        new BookCategory {Category = dystopian },
                        new BookCategory {Category = fiction }
                    },
                    Reviews = new List<Review>
                    {
                        new Review {Title = "Chilling", Text = "Still relevant today.", Reviewer = reviewer3 },
                        new Review {Title = "Depressing but insightful", Text = "A dark yet powerful novel", Reviewer = reviewer1 }
                    }
                };

                var book3 = new Book
                {
                    Name = "To kill a Mockingbird",
                    PublicationDate = new DateTime(1960, 7, 11),
                    BookCategories = new List<BookCategory>
                    {
                        new BookCategory {Category = classic },
                        new BookCategory {Category = fiction}
                    },
                    Reviews = new List<Review>
                    {
                        new Review {Title = "A true classic", Text = "Powerful themes and memorable characters.", Reviewer = reviewer2 },
                        new Review {Title = "Moving and timeless", Text = "An essential read for everyone.", Reviewer = reviewer3}
                    }
                };

                _dataContext.Books.AddRange(book1, book2, book3);

                var library1 = new Library
                {
                    Name = "Central Library",
                    Location = "Downtown",
                    Country = usa,
                    BookLibraries = new List<BookLibrary>
                    {
                        new BookLibrary { Book = book1},
                        new BookLibrary { Book = book2}
                    }
                };

                var library2 = new Library
                {
                    Name = "British Library",
                    Location = "London",
                    Country = uk,
                    BookLibraries = new List<BookLibrary>
                    {
                        new BookLibrary {Book = book2},
                        new BookLibrary {Book = book3}
                    }
                };

                _dataContext.Libraries.AddRange(library1, library2);
                _dataContext.SaveChanges();



            }
        }
    }
}
