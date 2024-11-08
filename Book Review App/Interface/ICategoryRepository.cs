using Book_Review_App.Models;

namespace Book_Review_App.Interface
{
    public interface ICategoryRepository
    {
       ICollection<Category> GetCategories();
        Category GetCategory(int id);

        ICollection<Book> GetBookByCategory(int categoryId);

        bool CategoryExists(int id);
    }
}
