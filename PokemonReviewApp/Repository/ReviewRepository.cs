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
    }
}
