using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.CardsViewModel;
using RecipeWebsite.ViewModels.PostViewModel;
using SimpleWebsite.Models;
using SimpleWebsite.ViewModels;

namespace RecipeWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostInterface _postInterface;
        public readonly ITagsInterface _tagsInterface;
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
                PostCard = await _context.Posts.Include(p => p.PostTags)
                                .ThenInclude(t => t.Tag)
                                .ToListAsync(),
                Categories = await _context.RecipeCategories.ToListAsync()
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
                // Image
                var result = await _photoInterface.AddPhotoAsync(postVM.Image);

                // Tags
                var tags = await _tagsInterface.GetAll();

                List<TagsModel> selectedTags = new List<TagsModel>();

                if (postVM.Tags != null && postVM.Tags.Any())
                {
                    selectedTags = tags.Where(x => postVM.Tags.Contains(x.Id)).ToList();
                }


                var post = new PostModel
                {
                    // Post
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = result.Url.ToString(),

                    // Genere
                    Category = postVM.Category,
                    Tags = selectedTags,

                    // Addition
                    Date = DateTime.Now,
                    TotalViews = postVM.View,
                    TotalLikes = postVM.Like,
                    TotalDislikes = postVM.Dislike
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
                Posts = await _context.Posts.Include(p => p.PostTags)
                                    .ThenInclude(t => t.Tag)
                                    .SingleAsync(p => p.Id == id),
                Categories = await _context.RecipeCategories.ToListAsync(),
            };

            post.Posts.TotalViews++;

            _context.Update(post.Posts);
            await _context.SaveChangesAsync();

            return View(post);
        }

        // Total Likes
        public async Task<IActionResult> Like(int id)
        {
            PostModel post = await _postInterface.GetByIdAsync(id);

            post.TotalLikes++;
            post.TotalViews--;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }

        // Total Dislikes
        public async Task<IActionResult> Dislike(int id)
        {
            PostModel post = await _postInterface.GetByIdAsync(id);

            post.TotalDislikes++;
            post.TotalViews--;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }


        // Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Id Check
            var post = await _postInterface.GetByIdAsync(id);

            // Check
            if (post == null)
            {
                return View("Error");
            }

            // Initialize Selected Tags
            var Results = from t in _context.RecipeTags
                          select new
                          {
                              t.Id,
                              t.TagsName,
                              t.TagsDescription,
                              Selected = ((from pt in _context.PostTags
                                           where (pt.PostId == id) & (pt.TagId == t.Id)
                                           select pt).Count() > 0),

                          };

            // Tags List
            var TagList = new List<SelectedItemViewModel>();

            // Selected Tags
            foreach (var item in Results)
            {
                TagList.Add(new SelectedItemViewModel
                {
                    Id = item.Id,
                    Name = item.TagsName,
                    Description = item.TagsDescription,
                    Selected = item.Selected
                });
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

                // Genere
                Category = post.Category,
                Tags = TagList,

                // Addition
                Date = post.Date,
                View = post.TotalViews,
                Like = post.TotalLikes,
                Dislike = post.TotalDislikes,

                // Genere List
                CategoryList = await _context.RecipeCategories.ToListAsync()
            };
            return View(postVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            // Check
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post");

                return View("Edit", postVM);
            }

            // Id Select
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

                    // Genere
                    Category = postVM.Category,

                    // Addition
                    Date = postVM.Date,
                    TotalViews = postVM.View,
                    TotalLikes = postVM.Like,
                    TotalDislikes = postVM.Dislike,
                };

                // Delete Selected Tags
                foreach (var item in _context.PostTags)
                {
                    if (item.PostId == id)
                    {
                        _context.Entry(item).State = EntityState.Deleted;
                    }
                }

                // Update Selected tags
                foreach (var item in postVM.Tags)
                {
                    if (item.Selected)
                    {
                        _context.PostTags.Add(new PostTagModel()
                        {
                            PostId = id,
                            TagId = item.Id
                        });
                    }
                }

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
