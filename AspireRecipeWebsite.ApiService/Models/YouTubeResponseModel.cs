namespace AspireRecipeWebsite.ApiService.Models
{
    public class YouTubeResponseModel
    {
        public List<YouTubeModel> YouTubeDetails { get; set; } = new List<YouTubeModel>();
        public string? NextPageToken { get; set; }
        public string? PreviousPageToken { get; set; }
    }
}
