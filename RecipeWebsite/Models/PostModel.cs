using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SimpleWebsite.Models;

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


        // Addition
        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }


        // Category
        public int Category { get; set; }


        // Tags
        public List<TagsModel> Tags { get; set; } = new List<TagsModel>();
        // Many To Many
        public virtual List<PostTagModel> PostTags { get; set; } = new List<PostTagModel>();


        // App User
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUserModel? AppUser { get; set; }
    }
}
