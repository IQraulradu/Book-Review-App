﻿namespace Book_Review_App.DTO.UserManagmentDTO
{
    public class BorrowedBookDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Status { get; set; }

    }
}
