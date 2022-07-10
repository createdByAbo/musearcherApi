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
                HttpResponseMessage response = await Client.GetAsync($"{link.Replace(" ", "%20")}&access_token={EnvReader.GetStringValue("apiKey").Replace(" ", "")}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return $"error requesting api / Message {e.Message}";
            }
        }
    }
}