using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository.IRepository;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _categoryRepository;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryRepository = context;
        }



        public bool CategoryExists(int id)
        {
            return _categoryRepository.Categories.Any(c => c.Id == id);
        }



        public ICollection<Category> GetCategories()
        {
            return _categoryRepository.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _categoryRepository.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonbyCategory(int categoryId)
        {
            return _categoryRepository.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
