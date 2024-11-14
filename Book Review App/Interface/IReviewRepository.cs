using Book_Review_App.Models;

namespace Book_Review_App.Interface
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfBook(int bookId);
        bool ReviewExists(int reviewId);

        bool CreateReview(Review review);
        bool Save();

    }
}
