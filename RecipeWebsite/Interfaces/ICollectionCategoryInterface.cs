using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface ICollectionCategoryInterface
    {
        Task<IEnumerable<CollectionCategoryModel>> GetAll();
        Task<CollectionCategoryModel> GetByIdAsync(int id);
        Task<CollectionCategoryModel> GetByIdAsyncNoTracking(int id);
        bool Add(CollectionCategoryModel collectionCategory);
        bool Update(CollectionCategoryModel collectionCategory);
        bool Delete(CollectionCategoryModel collectionCategory);
        bool Save();
    }
}
