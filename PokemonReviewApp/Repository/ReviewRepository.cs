using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository.IRepository;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewRepository(ApplicationDbContext context, IMapper mapper)
        {
            _reviewRepository = context;
            _mapper = mapper;
        }

        public bool CreateReview(Review review)
        {
            _reviewRepository.Add(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _reviewRepository.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _reviewRepository.RemoveRange(reviews);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _reviewRepository.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _reviewRepository.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _reviewRepository.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewRepository.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            var saved = _reviewRepository.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _reviewRepository.Update(review);
            return Save();
        }
    }
}
