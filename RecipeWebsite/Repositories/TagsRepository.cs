using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories
{
    public class TagsRepository : ITagsInterface
    {
        private readonly ApplicationDbContext _context;

        public TagsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(TagsModel tags)
        {
            _context.Add(tags);
            return Save();
        }

        public bool Delete(TagsModel tags)
        {
            _context.Remove(tags);
            return Save();
        }

        public bool DeleteFromTag(TagsModel tags)
        {
            _context.Remove(tags);
            return Save();
        }

        public async Task<IEnumerable<TagsModel>> GetAll()
        {
            return await _context.RecipeTags.ToListAsync();
        }

        public async Task<TagsModel> GetByIdAsync(int id)
        {
            return await _context.RecipeTags.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<TagsModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.RecipeTags.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(TagsModel tags)
        {
            _context.Update(tags);
            return Save();
        }
    }
}
