using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository.IRepository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonbyCategory(int categoryId );
        bool CategoryExists(int id );   
    }
}
 