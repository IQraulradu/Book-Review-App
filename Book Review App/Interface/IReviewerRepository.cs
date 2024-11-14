using Book_Review_App.Models;

namespace Book_Review_App.Interface
{
    public interface IReviewerRepository
    {
        public ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerid);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);

        bool CreateReviewer(Reviewer reviewerId);
        bool Save();
    }
}
