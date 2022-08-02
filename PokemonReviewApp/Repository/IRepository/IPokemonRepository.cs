using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository.IRepository
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
