﻿using Book_Review_App.Models;

namespace Book_Review_App.Interface
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
       /* Book GetBook(string name);*/
        decimal GetBookRating(int bookId);
        bool BookExists(int bookId);
        bool CreateBook(int libraryId, int categoryId, Book book);
        bool UpdateBook(int libraryId, int categoryId, Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
