﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RecipeWebsite.Data;

namespace RecipeWebsite.Controllers
{
    public class FilterController : Controller
    {
        //private readonly IMemoryCache _cache;
        //private readonly ApplicationDbContext _context;

        //public FilterController(ApplicationDbContext context, IMemoryCache cache)
        //{
        //    _context = context;
        //    _cache = cache;
        //}

        //[HttpPost]
        //public IActionResult Index(PostCategory? postCategory)
        //{
        //    List<Post> post;

        //    if (postCategory != null)
        //    {
        //        post = _context.Posts.Where(c => c.PostCategory == postCategory).ToList();
        //    }
        //    else
        //    {
        //        post = _context.Posts.ToList();
        //    }

        //    _cache.Set("post", post);
        //    ViewBag.PostCategory = postCategory;

        //    string url = Request.Headers["Referer"].ToString();

        //    return Redirect(url);
        //}
    }
}
