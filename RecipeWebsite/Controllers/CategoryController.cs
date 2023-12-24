using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.GenereViewModel;
using RecipeWebsite.ViewModels.GenereViewModel.CategoryViewModel;

namespace RecipeWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface _postCategoryInterface;
        private readonly ApplicationDbContext _context;

        public CategoryController(ICategoryInterface postCategoryInterface, ApplicationDbContext context)
        {
            _postCategoryInterface = postCategoryInterface;
            _context = context;
        }

        // Index
        public async Task <IActionResult> Index()
        {
            var PostCategoryVM = new GenereViewModel
            {
                PostCategories = await _context.RecipeCategories.ToListAsync()
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

                _postCategoryInterface.Add(postCategory);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "post category creation failed.");
            }

            return View(postCategoryVM);
        }


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var postCategory = await _postCategoryInterface.GetByIdAsync(id);

            if (postCategory == null) return View("Error");

            var postCategoryVM = new EditCategoryViewModel
            {
                CategoryName = postCategory.CategoryName
            };

            return View(postCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel postCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post category");
                return View("Edit", postCategoryVM);
            }

            var userPost = await _postCategoryInterface.GetByIdAsyncNoTracking(id);

            if (userPost != null)
            {
                var postCategory = new CategoryModel
                {
                    Id = id,
                    CategoryName = postCategoryVM.CategoryName
                };

                _postCategoryInterface.Update(postCategory);

                return RedirectToAction("Index");
            }
            else
            {
                return View(postCategoryVM);
            }
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var postCategoryDetails = await _postCategoryInterface.GetByIdAsync(id);

            if (postCategoryDetails == null) return View("Error");

            return View(postCategoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postCategoryDetails = await _postCategoryInterface.GetByIdAsync(id);

            if (postCategoryDetails == null) return View("Error");

            _postCategoryInterface.Delete(postCategoryDetails);

            return RedirectToAction("Index");
        }
    }
}