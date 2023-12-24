using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories
{
    public class CategoryRepository : ICategoryInterface
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(CategoryModel category)
        {
            _context.Add(category);
            return Save();
        }

        public bool Delete(CategoryModel category)
        {
            _context.Remove(category);
            return Save();
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            return await _context.RecipeCategories.ToListAsync();
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            return await _context.RecipeCategories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<CategoryModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.RecipeCategories.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CategoryModel category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
