using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface ICollectionInterface
    {
        Task<IEnumerable<CollectionModel>> GetAll();
        Task<CollectionModel> GetByIdAsync(int id);
        Task<CollectionModel> GetByIdAsyncNoTracking(int id);
        bool Add(CollectionModel collection);
        bool Update(CollectionModel collection);
        bool Delete(CollectionModel collection);
        bool Save();
    }
}
