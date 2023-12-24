using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.CardsViewModel;
using RecipeWebsite.ViewModels.PostViewModel;

namespace RecipeWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostInterface _postInterface;
        private readonly ITagsInterface _tagsInterface;
        private readonly IPhotoInterface _photoInterface;
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public PostController(IPostInterface postInterface,
                                IPhotoInterface photoInterface,
                                ApplicationDbContext context,
                                IMemoryCache cache,
                                ITagsInterface tagsInterface)
        {
            _postInterface = postInterface;
            _photoInterface = photoInterface;
            _context = context;
            _cache = cache;
            _tagsInterface = tagsInterface;
        }


        // Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Category filtered Posts
            var cached = _cache.TryGetValue("filteredCategory", out var filteredCategory);

            if (cached)
            {
                return View(filteredCategory);
            }


            // All Posts
            var CardPostVM = new CardsViewModel
            {
                PostCard = await _context.Posts.ToListAsync(),
                Tags = await _context.RecipeTags.ToListAsync()
            };

            return View(CardPostVM);
        }

        // Searchbar
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            TempData["postSearch"] = searchString;

            var post = from p in _context.Posts select p;
                        
            if (!string.IsNullOrEmpty(searchString))
            {
                post = post.Where( t => t.Title!.Contains(searchString) ||
                                        t.Ingredient!.Contains(searchString));
            }

            var CardPostVM = new CardsViewModel
            {
                PostCard = await post.ToListAsync()
            };

            return View(CardPostVM);
        }


        // Create
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            // Category List
            var CreatePostCategoryVM = new CreatePostViewModel
            {
                CategoryList = await _context.RecipeCategories.ToListAsync(),
                TagsList = await _context.RecipeTags.ToListAsync()
            };

            return View(CreatePostCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoInterface.AddPhotoAsync(postVM.Image);
                
                var post = new PostModel
                {
                    // Post
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = result.Url.ToString(),

                    // Category
                    Category = postVM.Category,
                    Tags = string.Join(',', postVM.Tags),

                    // Addition
                    Date = DateTime.Now,
                    View = postVM.View,
                    Like = postVM.Like,
                    Dislike = postVM.Dislike
                };

                _postInterface.Add(post);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(postVM);
        }


        // Details
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var post = new DetailPostViewModel
            {
                Posts = await _postInterface.GetByIdAsync(id),
                Tags = await _context.RecipeTags.ToListAsync()
            };

            post.Posts.View++;

            _context.Update(post.Posts);
            await _context.SaveChangesAsync();

            return View(post);
        }

        // Like
        public async Task<IActionResult> Like(int id)
        {
            PostModel post = await _postInterface.GetByIdAsync(id);

            post.Like++;
            post.View--;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }

        // Dislike
        public async Task<IActionResult> Dislike(int id)
        {
            PostModel post = await _postInterface.GetByIdAsync(id);

            post.Dislike++;
            post.View--;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }


        // Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postInterface.GetByIdAsync(id);

            if (post == null)
            {
                return View("Error");
            }

            var postVM = new EditPostViewModel
            {
                // Post
                Title = post.Title,
                Description = post.Description,
                Link = post.Link,
                Ingredient = post.Ingredient,
                URL = post.Image,
                Recipe = post.Recipe,

                // Category
                Category = post.Category,
                //// Tags = string.Join(',', post.Tags), //// Do not open

                // Addition
                Date = post.Date,
                View = post.View,
                Like = post.Like,
                Dislike = post.Dislike,

                // Category List
                CategoryList = await _context.RecipeCategories.ToListAsync(),
                TagsList = await _context.RecipeTags.ToListAsync()
            };
            return View(postVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post");
                return View("Edit", postVM);
            }

            var userPost = await _postInterface.GetByIdAsyncNoTracking(id);


            if (userPost != null)
            {
                try
                {
                    await _photoInterface.DeletePhotoAsync(userPost.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(postVM);
                }
                var photoResult = await _photoInterface.AddPhotoAsync(postVM.Image);

                var post = new PostModel
                {
                    // Post
                    Id = id,
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = photoResult.Url.ToString(),

                    // Category
                    Category = postVM.Category,
                    Tags = string.Join(',', postVM.Tags),

                    // Addition
                    Date = postVM.Date,
                    View = postVM.View,
                    Like = postVM.Like,
                    Dislike = postVM.Dislike,
                };

                _postInterface.Update(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View(postVM);
            }
        }


        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var postDetails = await _postInterface.GetByIdAsync(id);

            if (postDetails == null)
            {
                return View("Error");
            }

            return View(postDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDetails = await _postInterface.GetByIdAsync(id);

            if (postDetails == null)
            {
                return View("Error");
            }

            _postInterface.Delete(postDetails);
            return RedirectToAction("Index");
        }
    }
}
