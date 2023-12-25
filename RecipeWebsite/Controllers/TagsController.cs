using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.ViewModels.GenereViewModel.TagsViewModel;
using RecipeWebsite.ViewModels.CardsViewModel;
using RecipeWebsite.ViewModels.GenereViewModel;

namespace RecipeWebsite.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagsInterface _tagsInterface;
        private readonly ApplicationDbContext _context;

        public TagsController(ITagsInterface tagsInterface,
                                ApplicationDbContext context)
        {
            _tagsInterface = tagsInterface;
            _context = context;
        }

        // Index
        public async Task<IActionResult> Index()
        {
            var TagsVM = new GenereViewModel
            {
                RecipeTags = await _context.RecipeTags.ToListAsync()
            };

            return View(TagsVM);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTagsViewModel tagsVM)
        {
            if (ModelState.IsValid)
            {
                var tags = new TagsModel
                {
                    TagsName = tagsVM.TagsName,
                    TagsDescription = tagsVM.TagsDescription
                };
                _tagsInterface.Add(tags);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "collection category creation failed.");
            }

            return View(tagsVM);
        }


        // Detail
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var taggedPosts = await (from p in _context.Posts select p).ToListAsync();

            taggedPosts = taggedPosts.Where(p => p.Tags.Split(',')
                                                        .Select(p => Convert.ToInt32(p))
                                                        .Contains(id)).ToList();

            var CardPostVM = new CardsViewModel
            {
                TagInfo = await _tagsInterface.GetByIdAsync(id),

                PostCard = taggedPosts,

                Categories = await _context.RecipeCategories.ToListAsync(),
                Tags = await _context.RecipeTags.ToListAsync()
            };

            return View(CardPostVM);
        }


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var tags = await _tagsInterface.GetByIdAsync(id);

            if (tags == null) return View("Error");

            var TagsVM = new EditTagsViewModel
            {
                TagsName = tags.TagsName,
                TagsDescription = tags.TagsDescription
            };

            return View(TagsVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,
                                                EditTagsViewModel tagsVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit collection category");
                return View("Edit", tagsVM);
            }

            var userCollection = await _tagsInterface.GetByIdAsyncNoTracking(id);

            if (userCollection != null)
            {
                var tags = new TagsModel
                {
                    Id = id,
                    TagsName = tagsVM.TagsName,
                    TagsDescription = tagsVM.TagsDescription
                };

                _tagsInterface.Update(tags);

                return RedirectToAction("Index");
            }
            else
            {
                return View(tagsVM);
            }
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var tagsDetails = await _tagsInterface.GetByIdAsync(id);

            if (tagsDetails == null) return View("Error");

            return View(tagsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tagsDetails = await _tagsInterface.GetByIdAsync(id);

            if (tagsDetails == null) return View("Error");

            _tagsInterface.Delete(tagsDetails);

            return RedirectToAction("Index");
        }


        // Delete From Tag
        public async Task<IActionResult> DeleteFromTag(int id)
        {
            var tagsDetails = await _tagsInterface.GetByIdAsync(id);

            if (tagsDetails == null) return View("Error");

            return View(tagsDetails);
        }

        [HttpPost, ActionName("DeleteFromTag")]
        public async Task<IActionResult> DeleteFromTagDetails(int id)
        {
            var tagsDetails = await _tagsInterface.GetByIdAsync(id);

            if (tagsDetails == null) return View("Error");

            _tagsInterface.Delete(tagsDetails);

            return RedirectToAction("Index");
        }
    }
}