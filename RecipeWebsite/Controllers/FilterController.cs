using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RecipeWebsite.Data;
using RecipeWebsite.ViewModels.CardsViewModel;

namespace RecipeWebsite.Controllers
{
    public class FilterController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext _context;

        public FilterController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IActionResult> Index(string postCategory)
        {
            ViewBag.PostCategory = postCategory;

            var filteredPost = from p in _context.Posts select p;

            if (postCategory == "All")
            {
                filteredPost = _context.Posts;
            }
            else if (!string.IsNullOrEmpty(postCategory))
            {
                //filteredPost = filteredPost.Where(p => p.Category == postCategory);
            }

            var filteredCategory = new CardsViewModel
            {
                PostCard = await filteredPost.ToListAsync()
            };

            _cache.Set("filteredCategory", filteredCategory);

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }
    }
}
