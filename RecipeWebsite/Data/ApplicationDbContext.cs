using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;
using SimpleWebsite.Models;

namespace RecipeWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Views
        public DbSet<CollectionModel> Collections { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        // Genere
        public DbSet<TagsModel> RecipeTags { get; set; }
        public DbSet<CategoryModel> RecipeCategories { get; set; }


        // Relations
        // PostTags
        public DbSet<PostTagModel> PostTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostModel>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .UsingEntity<PostTagModel>();
        }
    }
}
