using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories
{
    public class CollectionCategoryRepository : ICollectionCategoryInterface
    {
        private readonly ApplicationDbContext _context;

        public CollectionCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(CollectionCategoryModel collectionCategory)
        {
            _context.Add(collectionCategory);
            return Save();
        }

        public bool Delete(CollectionCategoryModel collectionCategory)
        {
            _context.Remove(collectionCategory);
            return Save();
        }

        public async Task<IEnumerable<CollectionCategoryModel>> GetAll()
        {
            return await _context.CollectionCategories.ToListAsync();
        }

        public async Task<CollectionCategoryModel> GetByIdAsync(int id)
        {
            return await _context.CollectionCategories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<CollectionCategoryModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.CollectionCategories.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CollectionCategoryModel collectionCategory)
        {
            _context.Update(collectionCategory);
            return Save();
        }
    }
}
