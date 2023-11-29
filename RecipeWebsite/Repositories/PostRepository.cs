using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories
{
    public class PostRepository : IPostInterface
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(PostModel post)
        {
            _context.Add(post);
            return Save();
        }

        public bool Delete(PostModel post)
        {
            _context.Remove(post);
            return Save();
        }

        public async Task<IEnumerable<PostModel>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<PostModel> GetByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PostModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(PostModel post)
        {
            _context.Update(post);
            return Save();
        }
    }
}
