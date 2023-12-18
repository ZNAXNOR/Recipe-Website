using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class PostModel
    {
        // Post
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? Ingredient { get; set; }
        public string Recipe { get; set; }
        public string Image { get; set; }


        // Category
        public string PostCategory { get; set; }
        public string? Tags { get; set; }


        // Addition
        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }


        // App User
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUserModel? AppUser { get; set; }
    }
}
