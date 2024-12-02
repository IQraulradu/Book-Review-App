﻿namespace Book_Review_App.Models.UserManagment
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}
