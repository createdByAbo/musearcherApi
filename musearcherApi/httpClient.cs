namespace musearcherApi
{
    using dotenv.net;
    using dotenv.net.Utilities;
    public class httpClient
    {
        static readonly HttpClient Client = new HttpClient();

        public static async Task<string> Get(string link, string provider)
        {
            try
            {
                switch (provider)
                {
                    case "genius":
                        DotEnv.Load();
                        HttpResponseMessage geniusResponse = await Client.GetAsync($"{link.Replace(" ", "%20")}&access_token={EnvReader.GetStringValue("geniusApiKey").Replace(" ", "")}");
                        geniusResponse.EnsureSuccessStatusCode();
                        var geniusResponseBody = await geniusResponse.Content.ReadAsStringAsync();
                        return geniusResponseBody;
                    case "spotify":
                        DotEnv.Load();
                        HttpResponseMessage spotifyResponse = await Client.GetAsync($"{link.Replace(" ", "%20")}&access_token={EnvReader.GetStringValue("spotifyApiKey").Replace(" ", "")}");
                        spotifyResponse.EnsureSuccessStatusCode();
                        var spotifyResponseBody = await spotifyResponse.Content.ReadAsStringAsync();
                        return spotifyResponseBody;
                    case "youtube":
                        DotEnv.Load();
                        HttpResponseMessage youtubeResponse = await Client.GetAsync($"{link.Replace(" ", "%20")}&access_token={EnvReader.GetStringValue("spotifyApiKey").Replace(" ", "")}");
                        youtubeResponse.EnsureSuccessStatusCode();
                        var youtubeResponseBody = await youtubeResponse.Content.ReadAsStringAsync();
                        return youtubeResponseBody;
                }
            }
            catch (HttpRequestException e)
            {
                return $"error requesting api / Message {e.Message}";
            }

            return null;
        }
    }
}