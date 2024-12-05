using Book_Review_App.Models.UserManagment;
using Microsoft.EntityFrameworkCore;

namespace Book_Review_App.Data
{
    public class DataContextUser : DbContext
    {
        public DataContextUser(DbContextOptions<DataContextUser> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1-M
            modelBuilder.Entity<FavoriteBook>()
                .HasOne(fb => fb.User)
                .WithMany(u => u.FavoriteBooks)
                .HasForeignKey(fb => fb.UserId);
            //1-M

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(bb => bb.UserId);

            //M-M
            modelBuilder.Entity<FavoriteBook>()
                .HasOne(fb => fb.Book)
                .WithMany(b => b.FavoriteBooks)
                .HasForeignKey(fb => fb.BookId);

            //M-M
            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.BorrowedBooks)
                .HasForeignKey(bb => bb.BookId);

            //1-M
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
                


        }



    }
}
