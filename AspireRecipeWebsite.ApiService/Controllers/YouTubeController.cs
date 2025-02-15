using AspireRecipeWebsite.ApiService.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;

namespace AspireRecipeWebsite.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouTubeController : Controller
    {
        private readonly IConfiguration _configuration;

        public YouTubeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetChannelVideos(string? pageToken = null, int maxResults = 20)
        {
            var youtubeApiKey = _configuration["API:YouTube"];
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = youtubeApiKey,
                ApplicationName = "AspireRecipeWebsite"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.ChannelId = "UCDPm-88KsBdiSQ6ZlgMPe4g";
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchListRequest.MaxResults = maxResults;
            searchListRequest.PageToken = pageToken;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            var videoList = searchListResponse.Items.Select(item => new YouTubeModel
            {
                Title = item.Snippet.Title,
                Link = $"https://www.youtube.com/watch?v={item.Id.VideoId}",
                Thumbnail = item.Snippet.Thumbnails.Medium.Url,
                PublishedAt = item.Snippet.PublishedAtDateTimeOffset
            })
            .OrderByDescending(video => video.PublishedAt).ToList();

            var responseModel = new YouTubeResponseModel
            {
                YouTubeDetails = videoList,
                NextPageToken = searchListResponse.NextPageToken,
                PreviousPageToken = searchListResponse.PrevPageToken
            };

            return Ok(responseModel);
        }
    }
}
