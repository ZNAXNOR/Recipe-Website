using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.ViewModels.CardsViewModel;

namespace RecipeWebsite.Controllers
{
    public class SearchbarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchbarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var posts = from p in _context.Posts select p;
            var collections = from c in _context.Collections select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                TempData["searchString"] = searchString;

                posts = posts.Where(p => p.Title!.Contains(searchString) ||
                                         p.Ingredient!.Contains(searchString));

                collections = collections.Where(c => c.CollectionTitle!.Contains(searchString));
            }

            var CardPostVM = new CardsViewModel
            {
                PostCard = await posts.ToListAsync(),
                CollectionCard = await collections.ToListAsync()
            };

            return View(CardPostVM);
        }
    }
}
