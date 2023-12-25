using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.CardsViewModel;
using RecipeWebsite.ViewModels.GenereViewModel;
using RecipeWebsite.ViewModels.GenereViewModel.CategoryViewModel;

namespace RecipeWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface _categoryInterface;
        private readonly ApplicationDbContext _context;

        public CategoryController(ICategoryInterface categoryInterface, ApplicationDbContext context)
        {
            _categoryInterface = categoryInterface;
            _context = context;
        }


        // Index
        public async Task <IActionResult> Index()
        {
            var PostCategoryVM = new GenereViewModel
            {
                RecipeCategories = await _context.RecipeCategories.ToListAsync()
            };

            return View(PostCategoryVM);
        }


        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel postCategoryVM)
        {
            if (ModelState.IsValid)
            {
                var postCategory = new CategoryModel
                {
                    CategoryName = postCategoryVM.CategoryName
                };

                _categoryInterface.Add(postCategory);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "post category creation failed.");
            }

            return View(postCategoryVM);
        }


        // Detail
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var postCategory = from p in _context.Posts select p;

            postCategory = postCategory.Where(p => p.Category == id);

            var CardPostVM = new CardsViewModel
            {
                CategoryInfo = await _categoryInterface.GetByIdAsync(id),
                PostCard = await postCategory.ToListAsync(),
                Categories = await _context.RecipeCategories.ToListAsync()
            };

            return View(CardPostVM);
        }


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryInterface.GetByIdAsync(id);

            if (category == null) return View("Error");

            var categoryVM = new EditCategoryViewModel
            {
                CategoryName = category.CategoryName
            };

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel categoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post category");
                return View("Edit", categoryVM);
            }

            var userPost = await _categoryInterface.GetByIdAsyncNoTracking(id);

            if (userPost != null)
            {
                var category = new CategoryModel
                {
                    Id = id,
                    CategoryName = categoryVM.CategoryName
                };

                _categoryInterface.Update(category);

                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryVM);
            }
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _categoryInterface.GetByIdAsync(id);

            if (categoryDetails == null) return View("Error");

            return View(categoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var categoryDetails = await _categoryInterface.GetByIdAsync(id);

            if (categoryDetails == null) return View("Error");

            _categoryInterface.Delete(categoryDetails);

            return RedirectToAction("Index");
        }


        // Delete From Category
        public async Task<IActionResult> DeleteFromCategory(int id)
        {
            var categoryDetails = await _categoryInterface.GetByIdAsync(id);

            if (categoryDetails == null) return View("Error");

            return View(categoryDetails);
        }

        [HttpPost, ActionName("DeleteFromCategory")]
        public async Task<IActionResult> DeleteFromCategoryDetails(int id)
        {
            var categoryDetails = await _categoryInterface.GetByIdAsync(id);

            if (categoryDetails == null) return View("Error");

            _categoryInterface.Delete(categoryDetails);

            return RedirectToAction("Index");
        }
    }
}