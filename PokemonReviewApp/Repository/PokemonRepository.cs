using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository.IRepository;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDbContext _pokemonRepository;
        public PokemonRepository(ApplicationDbContext context)
        {
            _pokemonRepository = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _pokemonRepository.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _pokemonRepository.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _pokemonRepository.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if (review.Count() <= 0 )
            {
                return 0;
            }
            else
            {
                return ((decimal)review.Sum(r=>r.Rating) / review.Count());
            }
         }

        public ICollection<Pokemon> GetPokemons()
        {
            return _pokemonRepository.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _pokemonRepository.Pokemons.Any(p => p.Id == pokeId);
        }
    }
}
