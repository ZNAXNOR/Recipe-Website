using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<CategoryModel> GetByIdAsync(int id);
        Task<CategoryModel> GetByIdAsyncNoTracking(int id);
        bool Add(CategoryModel category);
        bool Update(CategoryModel category);
        bool Delete(CategoryModel category);
        bool DeleteFromCategory(CategoryModel category);
        bool Save();
    }
}
