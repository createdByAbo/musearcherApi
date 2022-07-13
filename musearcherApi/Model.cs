using System.Net;
using Newtonsoft.Json;

namespace musearcherApi;

public class Model
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public HttpStatusCode Status { get; set; }
        public bool? IsHot { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public Uri? SongUrl { get; set; }
        public Uri? ThumbUrl { get; set; }
        public string? ReleseDate { get; set; }
        public string? SpotifyUrl { get; set; }
        public string? YoutubeUrl { get; set; }

        public static async Task<string> CreateJsonResponse(Welcome rawJson)
        {
            Response response = new Response();

            switch (rawJson.Meta.Status)
            {
                case 200:
                    response.IsSuccessful = true;
                    response.Status = HttpStatusCode.OK;
                    response.IsHot = rawJson.Response.Hits[0].Result.Stats.Hot == true ? response.IsHot = true : response.IsHot = false;
                    response.Title = rawJson.Response.Hits[0].Result.Title;
                    response.Author = rawJson.Response.Hits[0].Result.ArtistNames;
                    response.SongUrl = rawJson.Response.Hits[0].Result.Url;
                    response.ThumbUrl = rawJson.Response.Hits[0].Result.SongArtImageThumbnailUrl;
                    response.ReleseDate = rawJson.Response.Hits[0].Result.ReleaseDateForDisplay;

                    var spotifyUrl = await SpotifyClient.SearchTrack(response.Author, response.Title);
                    response.SpotifyUrl = spotifyUrl;

                    var youtubeUrl = await YoutubeClient.SearchTracks(response.Author, response.Title);
                    response.YoutubeUrl = youtubeUrl;
                    break;
                case 304:
                    response.IsSuccessful = true;
                    response.Status = HttpStatusCode.NotModified;
                    break;
                case 404:
                    response.IsSuccessful = false;
                    response.Status = HttpStatusCode.NotFound;
                    break;
                case 500:
                    response.IsSuccessful = false;
                    response.Status = HttpStatusCode.InternalServerError;
                    break;
            }

            string json = JsonConvert.SerializeObject(response);
            return json;
        }
    }
}