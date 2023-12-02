using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface IPostCategoryInterface
    {
        Task<IEnumerable<PostCategoryModel>> GetAll();
        Task<PostCategoryModel> GetByIdAsync(int id);
        Task<PostCategoryModel> GetByIdAsyncNoTracking(int id);
        bool Add(PostCategoryModel postCategory);
        bool Update(PostCategoryModel postCategory);
        bool Delete(PostCategoryModel postCategory);
        bool Save();
    }
}
