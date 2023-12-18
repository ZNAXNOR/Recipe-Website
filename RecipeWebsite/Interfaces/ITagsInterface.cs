using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface ITagsInterface
    {
        Task<IEnumerable<TagsModel>> GetAll();
        Task<TagsModel> GetByIdAsync(int id);
        Task<TagsModel> GetByIdAsyncNoTracking(int id);
        bool Add(TagsModel tags);
        bool Update(TagsModel tags);
        bool Delete(TagsModel tags);
        bool Save();
    }
}
