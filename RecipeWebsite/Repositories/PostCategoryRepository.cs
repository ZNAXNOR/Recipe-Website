using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories
{
    public class PostCategoryRepository : IPostCategoryInterface
    {
        private readonly ApplicationDbContext _context;

        public PostCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(PostCategoryModel postCategory)
        {
            _context.Add(postCategory);
            return Save();
        }

        public bool Delete(PostCategoryModel postCategory)
        {
            _context.Remove(postCategory);
            return Save();
        }

        public async Task<IEnumerable<PostCategoryModel>> GetAll()
        {
            return await _context.PostCategories.ToListAsync();
        }

        public async Task<PostCategoryModel> GetByIdAsync(int id)
        {
            return await _context.PostCategories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PostCategoryModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.PostCategories.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(PostCategoryModel postCategory)
        {
            _context.Update(postCategory);
            return Save();
        }
    }
}
