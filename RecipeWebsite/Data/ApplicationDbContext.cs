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

        // Genre
        public DbSet<TagsModel> RecipeTags { get; set; }
        public DbSet<CategoryModel> RecipeCategories { get; set; }



        // Many-To-Many Relations

        // PostTags
        public DbSet<PostTagModel> PostTags { get; set; }

        // PostCollections
        public DbSet<PostCollectionModel> PostCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PostTags
            modelBuilder.Entity<PostModel>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .UsingEntity<PostTagModel>();

            // PostCollections
            modelBuilder.Entity<PostModel>()
                .HasMany(e => e.Collections)
                .WithMany(e => e.Posts)
                .UsingEntity<PostCollectionModel>();
        }
    }
}
