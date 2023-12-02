using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.CategoryViewModel;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.ViewModels.CategoryViewModel.CollectionCategoryViewModel;

namespace RecipeWebsite.Controllers
{
    public class CollectionCategoryController : Controller
    {
        private readonly ICollectionCategoryInterface _collectionCategoryInterface;
        private readonly ApplicationDbContext _context;

        public CollectionCategoryController(ICollectionCategoryInterface collectionCategoryInterface, ApplicationDbContext context)
        {
            _collectionCategoryInterface = collectionCategoryInterface;
            _context = context;
        }

        // Index
        public async Task<IActionResult> Index()
        {
            var CollectionCategoryVM = new CategoryViewModel
            {
                CollectionCategories = await _context.CollectionCategories.ToListAsync()
            };

            return View(CollectionCategoryVM);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCollectionCategoryViewModel collectionCategoryVM)
        {
            if (ModelState.IsValid)
            {
                var collectionCategory = new CollectionCategoryModel
                {
                    CategoryName = collectionCategoryVM.CategoryName
                };

                _collectionCategoryInterface.Add(collectionCategory);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "collection category creation failed.");
            }

            return View(collectionCategoryVM);
        }


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var collectionCategory = await _collectionCategoryInterface.GetByIdAsync(id);

            if (collectionCategory == null) return View("Error");

            var CollectionCategoryVM = new EditCollectionCategoryViewModel
            {
                CategoryName = collectionCategory.CategoryName
            };

            return View(CollectionCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCollectionCategoryViewModel collectionCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit collection category");
                return View("Edit", collectionCategoryVM);
            }

            var userCollection = await _collectionCategoryInterface.GetByIdAsyncNoTracking(id);

            if (userCollection != null)
            {
                var collectionCategory = new CollectionCategoryModel
                {
                    Id = id,
                    CategoryName = collectionCategoryVM.CategoryName
                };

                _collectionCategoryInterface.Update(collectionCategory);

                return RedirectToAction("Index");
            }
            else
            {
                return View(collectionCategoryVM);
            }
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var collectionCategoryDetails = await _collectionCategoryInterface.GetByIdAsync(id);

            if (collectionCategoryDetails == null) return View("Error");

            return View(collectionCategoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collectionCategoryDetails = await _collectionCategoryInterface.GetByIdAsync(id);

            if (collectionCategoryDetails == null) return View("Error");

            _collectionCategoryInterface.Delete(collectionCategoryDetails);

            return RedirectToAction("Index");
        }
    }
}