using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository.IRepository;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ApplicationDbContext _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _reviewerRepository = context;
            _mapper = mapper;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _reviewerRepository.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerRepository.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerRepository.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerRepository.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
