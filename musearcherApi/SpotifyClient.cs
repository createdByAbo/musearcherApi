using Newtonsoft.Json;
using SpotifyAPI.Web;

namespace musearcherApi;

public class SpotifyClient
{
    public static async Task<string> SearchTrack(string artist, string title)
    {
        
        var config = SpotifyClientConfig
            .CreateDefault()
            .WithAuthenticator(new ClientCredentialsAuthenticator("4ae5e0c261d249188e7a6da82d7c1d36", Environment.GetEnvironmentVariable("spotifyApiKey") ?? throw new InvalidOperationException()));
        
        var spotify = new SpotifyAPI.Web.SpotifyClient(config);
        var song = await spotify.Search.Item(new SearchRequest(
            SearchRequest.Types.Track,
            $"{artist} - {title}"
            )
        );

        Console.WriteLine(JsonConvert.SerializeObject(song));

        try
        {
            return song.Tracks.Items?[0].ExternalUrls["spotify"] ?? throw new InvalidOperationException();
        }
        catch (ArgumentOutOfRangeException e)
        {
            return "error - ArgOutOfRangeExc";
        }
        catch (Exception e)
        {
            return $"exception - {e}";
        }
    }
}