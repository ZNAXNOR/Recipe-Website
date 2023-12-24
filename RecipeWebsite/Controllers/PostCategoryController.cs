using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.GenereViewModel;
using RecipeWebsite.ViewModels.GenereViewModel.PostCategoryViewModel;

namespace RecipeWebsite.Controllers
{
    public class PostCategoryController : Controller
    {
        private readonly IPostCategoryInterface _postCategoryInterface;
        private readonly ApplicationDbContext _context;

        public PostCategoryController(IPostCategoryInterface postCategoryInterface, ApplicationDbContext context)
        {
            _postCategoryInterface = postCategoryInterface;
            _context = context;
        }

        // Index
        public async Task <IActionResult> Index()
        {
            var PostCategoryVM = new GenereViewModel
            {
                PostCategories = await _context.PostCategories.ToListAsync()
            };

            return View(PostCategoryVM);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePostCategoryViewModel postCategoryVM)
        {
            if (ModelState.IsValid)
            {
                var postCategory = new PostCategoryModel
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

            var postCategoryVM = new EditPostCategoryViewModel
            {
                CategoryName = postCategory.CategoryName
            };

            return View(postCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPostCategoryViewModel postCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post category");
                return View("Edit", postCategoryVM);
            }

            var userPost = await _postCategoryInterface.GetByIdAsyncNoTracking(id);

            if (userPost != null)
            {
                var postCategory = new PostCategoryModel
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