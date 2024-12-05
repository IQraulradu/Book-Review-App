using Book_Review_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Book_Review_App.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookLibrary> BookLibraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookLibrary>()
                .HasKey(bl => new { bl.BookId, bl.LibraryId });
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            //Relationship Many to many

            modelBuilder.Entity<BookLibrary>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.BookLibraries)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookLibrary>()
                .HasOne(bl => bl.Library)
                .WithMany(b => b.BookLibraries)
                .HasForeignKey(bl => bl.LibraryId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            //Relationship One to many between Library and Country

            modelBuilder.Entity<Library>()
                .HasOne(l => l.Country)
                .WithMany(c => c.Libraries)
                .HasForeignKey(l => l.CountryId);

            // Relationship One to many between Book and Review

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            // Relationship One to many between Reviewer and Review

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(re => re.Reviews)
                .HasForeignKey(r => r.ReviewerId);

        }

    }
}
