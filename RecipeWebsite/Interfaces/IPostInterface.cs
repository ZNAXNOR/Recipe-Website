using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface IPostInterface
    {
        Task<IEnumerable<PostModel>> GetAll();
        Task<PostModel> GetByIdAsync(int id);
        Task<PostModel> GetByIdAsyncNoTracking(int id);
        bool Add(PostModel post);
        bool Update(PostModel post);
        bool Delete(PostModel post);
        bool Save();
    }
}
