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
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly IPostInterface _postInterface;
        public readonly ITagsInterface _tagsInterface;
        public readonly ICollectionInterface _collectionInterface;
        private readonly IPhotoInterface _photoInterface;

        public PostController(ApplicationDbContext context,
                                IMemoryCache cache,
                                IPostInterface postInterface,
                                ITagsInterface tagsInterface,
                                ICollectionInterface collectionInterface,
                                IPhotoInterface photoInterface)
        {
            _postInterface = postInterface;
            _photoInterface = photoInterface;
            _context = context;
            _cache = cache;
            _tagsInterface = tagsInterface;
            _collectionInterface = collectionInterface;
        }


        // Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cached = _cache.TryGetValue("filteredCategory", out var filteredCategory);

            if (cached)
            {
                return View(filteredCategory);
            }

            var CardPostVM = new CardsViewModel
            {
                PostCard = await _context.Posts.Include(post => post.PostTags)
                                                .ThenInclude(tag => tag.Tag)
                                                .ToListAsync(),
                Categories = await _context.RecipeCategories.ToListAsync()
            };

            return View(CardPostVM);
        }

        // Search bar
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            TempData["postSearch"] = searchString;

            var post = from _post in _context.Posts select _post;
                        
            if (!string.IsNullOrEmpty(searchString))
            {
                post = post.Where( post => post.Title!.Contains(searchString) ||
                                        post.Ingredient!.Contains(searchString));
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
                var image = await _photoInterface.AddPhotoAsync(postVM.Image);

                var tags = await _tagsInterface.GetAll();

                List<TagsModel> selectedTags = new List<TagsModel>();

                if (postVM.Tags != null && postVM.Tags.Any())
                {
                    selectedTags = tags.Where(tag => postVM.Tags.Contains(tag.Id)).ToList();
                }

                var post = new PostModel
                {
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = image.Url.ToString(),
                    Category = postVM.Category,
                    Tags = selectedTags,
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
            var Collection = from collection in _context.Collections
                          select new
                          {
                              collection.CollectionId,
                              collection.CollectionTitle,
                              collection.CollectionDescription,
                              Selected = ((from postCollection in _context.PostCollections
                                           where (postCollection.PostId == id) & (postCollection.CollectionId == collection.CollectionId)
                                           select postCollection).Count() > 0),

                          };

            var CollectionList = new List<SelectedItemViewModel>();

            foreach (var selectedCollection in Collection)
            {
                CollectionList.Add(new SelectedItemViewModel
                {
                    Id = selectedCollection.CollectionId,
                    Name = selectedCollection.CollectionTitle,
                    Description = selectedCollection.CollectionDescription,
                    Selected = selectedCollection.Selected
                });
            }

            var post = new DetailPostViewModel
            {
                Posts = await _context.Posts.Include(post => post.PostTags)
                                            .ThenInclude(tag => tag.Tag)
                                            .SingleAsync(post => post.Id == id),
                Categories = await _context.RecipeCategories.ToListAsync(),
                SelectedItems = CollectionList,
            };

            post.Posts.TotalViews++;

            _context.Update(post.Posts);

            await _context.SaveChangesAsync();

            return View(post);
                }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(int id, DetailPostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to update post");

                return View("Detail", postVM);
            }

            var userPost = await _postInterface.GetByIdAsyncNoTracking(id);

            if (userPost != null)
            {
                foreach (var selectedCollection in _context.PostCollections)
                {
                    if (selectedCollection.PostId == id)
                    {
                        _context.Entry(selectedCollection).State = EntityState.Deleted;
                    }
                }

                foreach (var addCollection in postVM.SelectedItems)
                {
                    if (addCollection.Selected)
                    {
                        _context.PostCollections.Add(new PostCollectionModel()
                        {
                            PostId = id,
                            CollectionId = addCollection.Id
                        });
                    }
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(postVM);
            }
        }

        // Total Likes
        public async Task<IActionResult> Like(int postId)
        {
            PostModel post = await _postInterface.GetByIdAsync(postId);

            post.TotalLikes++;
            post.TotalViews--;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referrer"].ToString();

            return Redirect(url);
        }

        // Total Dislikes
        public async Task<IActionResult> Dislike(int postId)
        {
            PostModel post = await _postInterface.GetByIdAsync(postId);

            post.TotalDislikes++;
            post.TotalViews--;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referrer"].ToString();

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

            var Tag = from tag in _context.RecipeTags
                          select new
                          {
                              tag.Id,
                              tag.TagsName,
                              tag.TagsDescription,
                              Selected = ((from pt in _context.PostTags
                                           where (pt.PostId == id) & (pt.TagId == tag.Id)
                                           select pt).Count() > 0),

                          };

            var TagList = new List<SelectedItemViewModel>();

            foreach (var selectedTag in Tag)
            {
                TagList.Add(new SelectedItemViewModel
                {
                    Id = selectedTag.Id,
                    Name = selectedTag.TagsName,
                    Description = selectedTag.TagsDescription,
                    Selected = selectedTag.Selected
                });
            }

            var postVM = new EditPostViewModel
            {
                Title = post.Title,
                Description = post.Description,
                Link = post.Link,
                Ingredient = post.Ingredient,
                URL = post.Image,
                Recipe = post.Recipe,
                Category = post.Category,
                SelectedItems = TagList,
                Date = post.Date,
                View = post.TotalViews,
                Like = post.TotalLikes,
                Dislike = post.TotalDislikes,
                CategoryList = await _context.RecipeCategories.ToListAsync()
            };
            return View(postVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            if (ModelState.IsValid)
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
                    Id = id,
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = photoResult.Url.ToString(),
                    Category = postVM.Category,
                    Date = postVM.Date,
                    TotalViews = postVM.View,
                    TotalLikes = postVM.Like,
                    TotalDislikes = postVM.Dislike,
                };

                foreach (var selectedTag in _context.PostTags)
                {
                    if (selectedTag.PostId == id)
                    {
                        _context.Entry(selectedTag).State = EntityState.Deleted;
                    }
                }

                foreach (var addTags in postVM.SelectedItems)
                {
                    if (addTags.Selected)
                    {
                        _context.PostTags.Add(new PostTagModel()
                        {
                            PostId = id,
                            TagId = addTags.Id
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
        public async Task<IActionResult> Delete(int postId)
        {
            var postDetails = await _postInterface.GetByIdAsync(postId);

            if (postDetails == null)
            {
                return View("Error");
            }

            return View(postDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var postDetails = await _postInterface.GetByIdAsync(postId);

            if (postDetails == null)
            {
                return View("Error");
            }

            _postInterface.Delete(postDetails);
            return RedirectToAction("Index");
        }
    }
}
