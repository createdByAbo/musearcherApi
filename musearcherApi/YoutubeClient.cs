namespace musearcherApi;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;

public static class YoutubeClient
{
    public static async Task<string> SearchTracks(string author, string title)
    {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = Environment.GetEnvironmentVariable("youtubeApiKey")
        });

        try
        {
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = $"{author}%20{title}";
            searchListRequest.MaxResults = 1;

            var searchListResponse = await searchListRequest.ExecuteAsync();
            string url = "https://www.youtube.com/watch?v=" + searchListResponse.Items[0].Id.VideoId;
            return url;
        }
        catch (Exception e)
        {
            return $"Exception - {e}";
        }
    }
}