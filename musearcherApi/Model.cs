using Newtonsoft.Json;

namespace musearcherApi;

public class Model
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public bool? IsHot { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public Uri? SongUrl { get; set; }
        public Uri? ThumbUrl { get; set; }
        public string? ReleseDate { get; set; }

        public static string createJsonResponse(Welcome rawJson)
        {
            Response response = new Response();
            
            if (rawJson.Meta.Status == 200)
            {
                response.IsSuccessful = true;
                response.IsHot = rawJson.Response.Hits[0].Result.Stats.Hot == true ? response.IsHot = true : response.IsHot = false;
                response.Title = rawJson.Response.Hits[0].Result.Title;
                response.Author = rawJson.Response.Hits[0].Result.ArtistNames;
                response.SongUrl = rawJson.Response.Hits[0].Result.Url;
                response.ThumbUrl = rawJson.Response.Hits[0].Result.SongArtImageThumbnailUrl;
                response.ReleseDate = rawJson.Response.Hits[0].Result.ReleaseDateForDisplay;  
            }
            else
            {
                response.IsSuccessful = false;
            }

            string json = JsonConvert.SerializeObject(response);
            return json;
        }
    }
}