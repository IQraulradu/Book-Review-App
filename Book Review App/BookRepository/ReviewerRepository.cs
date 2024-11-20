using AutoMapper;
using Book_Review_App.Data;
using Book_Review_App.Interface;
using Book_Review_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Review_App.BookRepository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ReviewerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Reviewer> GetReviewers()
        {
           return _context.Reviewers.ToList();

        }
        public Reviewer GetReviewer(int reviewerid)
        {
            return _context.Reviewers.Where(r => r.Id == reviewerid).Include(e => e.Reviews).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.Id == reviewerId);
        }

        public bool CreateReviewer(Reviewer reviewerId)
        {
            _context.Add(reviewerId);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReviewer(Reviewer reviewerId)
        {
           _context.Update(reviewerId);
            return Save();
        }
    }
}
