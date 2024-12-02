namespace Book_Review_App.Models.UserManagment
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    
       

    }
}
