using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;

namespace RecipeWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Pages
        public DbSet<CollectionModel> Collections { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        // Category
        public DbSet<TagsModel> RecipeTags { get; set; }
        public DbSet<CategoryModel> RecipeCategories { get; set; }
    }
}
