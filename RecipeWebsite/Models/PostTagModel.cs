using RecipeWebsite.Models;

namespace SimpleWebsite.Models
{
    public class PostTagModel
    {
        public int PostId { get; set; }
        public int TagId { get; set; }


        // Many to Many relationship
        public virtual PostModel Post { get; set; }
        public virtual TagsModel Tag { get; set; }
    }
}
