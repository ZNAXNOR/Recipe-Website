using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.CardsViewModel;
using RecipeWebsite.ViewModels.CollectionViewModel;
using RecipeWebsite.ViewModels.ManyToMany;

namespace RecipeWebsite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionInterface _collectionInterface;
        private readonly IPhotoInterface _photoInterface;
        private readonly ApplicationDbContext _context;

        public CollectionController(ICollectionInterface collectionInterface, IPhotoInterface photoInterface, ApplicationDbContext context)
        {
            _collectionInterface = collectionInterface;
            _photoInterface = photoInterface;
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var collections = from collection in _context.Collections select collection;

            if (!string.IsNullOrEmpty(searchString))
            {
                TempData["collectionSearch"] = searchString;

                collections = collections.Where(search_string => search_string.CollectionTitle!.Contains(searchString));
            }

            var CollectedPostVM = new CardsViewModel
            {
                CollectionCard = await collections.ToListAsync()
            };

            return View(CollectedPostVM);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionViewModel collectionVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoInterface.AddPhotoAsync(collectionVM.Image);

                var collection = new CollectionModel
                {
                    CollectionTitle = collectionVM.Title,
                    CollectionDescription = collectionVM.Description,
                    CollectionImage = result.Url.ToString()
                };
                _collectionInterface.Add(collection);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(collectionVM);
        }



        public async Task<IActionResult> Detail(int id)
        {
            var collectedPosts = _context.Collections.Include(postCollections => postCollections.PostCollections)
                                                .ThenInclude(post => post.Post)
                                                .ThenInclude(tag => tag.Tags)
                                                .Where(collection => collection.CollectionId == id);

            var CollectedPostVM = new CollectedPostViewModel
            {
                CollectionInfo = await _collectionInterface.GetByIdAsync(id),

                Collections = await collectedPosts.ToListAsync(),

                Categories = await _context.RecipeCategories.ToListAsync()
            };

            return View(CollectedPostVM);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var collection = await _collectionInterface.GetByIdAsync(id);
            if (collection == null)
            {
                return View("Error");
            }

            var collectionVM = new EditCollectionViewModel
            {
                Title = collection.CollectionTitle,
                Description = collection.CollectionDescription,
                URL = collection.CollectionImage
            };

            return View(collectionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCollectionViewModel collectionVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit collection");

                return View("Edit", collectionVM);
            }

            var userCollection = await _collectionInterface.GetByIdAsyncNoTracking(id);

            if (userCollection != null)
            {
                try
                {
                    await _photoInterface.DeletePhotoAsync(userCollection.CollectionImage);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");

                    return View(collectionVM);
                }

                var photoResult = await _photoInterface.AddPhotoAsync(collectionVM.Image);

                var collection = new CollectionModel
                {
                    CollectionId = id,
                    CollectionTitle = collectionVM.Title,
                    CollectionDescription = collectionVM.Description,
                    CollectionImage = photoResult.Url.ToString()
                };
                _collectionInterface.Update(collection);

                return RedirectToAction("Index");
            }
            else
            {
                return View(collectionVM);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            var collectionDetails = await _collectionInterface.GetByIdAsync(id);

            if (collectionDetails == null)
            {
                return View("Error");
            }

            return View(collectionDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collectionDetails = await _collectionInterface.GetByIdAsync(id);

            if (collectionDetails == null)
            {
                return View("Error");
            }

            _collectionInterface.Delete(collectionDetails);

            return RedirectToAction("Index");
        }
    }
}
