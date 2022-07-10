using SpotifyAPI.Web;

namespace musearcherApi;

public class SpotifyClient
{
    public static async Task SearchTrack(string Artist, string Title)
    {
        string getSpotifyUrl(string url)
        {
            return url;
        }
        
        var config = SpotifyClientConfig
            .CreateDefault()
            .WithAuthenticator(new ClientCredentialsAuthenticator("4ae5e0c261d249188e7a6da82d7c1d36", Environment.GetEnvironmentVariable("spotifyApiKey")));
        
        var spotify = new SpotifyAPI.Web.SpotifyClient(config);
        var song = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, $"{Artist} {Title}"));
        getSpotifyUrl(song.Tracks.Items[0].ExternalUrls["spotify"]);
    }
}