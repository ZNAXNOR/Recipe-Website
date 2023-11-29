using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories
{
    public class CollectionRepository : ICollectionInterface
    {
        private readonly ApplicationDbContext _context;

        public CollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CollectionModel collection)
        {
            _context.Add(collection);
            return Save();
        }

        public bool Delete(CollectionModel collection)
        {
            _context.Remove(collection);
            return Save();
        }

        public async Task<IEnumerable<CollectionModel>> GetAll()
        {
            return await _context.Collections.ToListAsync();
        }

        public async Task<CollectionModel> GetByIdAsync(int id)
        {
            return await _context.Collections.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<CollectionModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Collections.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CollectionModel collection)
        {
            _context.Update(collection);
            return Save();
        }
    }
}
