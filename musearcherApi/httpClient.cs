namespace musearcherApi
{
    using dotenv.net;
    using dotenv.net.Utilities;
    public class httpClient
    {
        static readonly HttpClient Client = new HttpClient();

        public static async Task<string> Get(string link)
        {
            try
            {
                DotEnv.Load();
                HttpResponseMessage geniusResponse = await Client.GetAsync($"{link.Replace(" ", "%20")}&access_token={EnvReader.GetStringValue("geniusApiKey").Replace(" ", "")}");
                geniusResponse.EnsureSuccessStatusCode();
                var geniusResponseBody = await geniusResponse.Content.ReadAsStringAsync();
                return geniusResponseBody;
            }
            catch (HttpRequestException e)
            {
                return $"error requesting api / Message {e.Message}";
            }
        }
    }
}