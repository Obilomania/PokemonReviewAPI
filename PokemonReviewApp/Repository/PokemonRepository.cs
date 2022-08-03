using PokemonReviewApp.Data;
using PokemonReviewApp.Data.Dto;
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

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _pokemonRepository.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _pokemonRepository.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _pokemonRepository.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _pokemonRepository.Add(pokemonCategory);

            _pokemonRepository.Add(pokemon);

            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _pokemonRepository.Remove(pokemon);
            return Save();
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

        public Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate)
        {
            return GetPokemons().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool PokemonExists(int pokeId)
        {
            return _pokemonRepository.Pokemons.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
            var saved = _pokemonRepository.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _pokemonRepository.Update(pokemon);
            return Save();
        }
    }
}
