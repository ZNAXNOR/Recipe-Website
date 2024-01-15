using SimpleWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class TagsModel
    {        
        [Key]
        public int Id { get; set; }
        public string TagsName { get; set; }
        public string? TagsDescription { get; set; }

        // Posts
        public List<PostModel> Posts { get; set; }
        // Posts Many to Many
        public virtual List<PostTagModel> PostTags { get; set; }
    }
}
