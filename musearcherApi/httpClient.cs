﻿namespace musearcherApi
{
    using dotenv.net;
    using dotenv.net.Utilities;
    public class httpClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<String> Get(string link)
        {
            try
            {
                DotEnv.Load();
                string apiKey = EnvReader.GetStringValue("apiKey").Replace(" ", "");
                string url = $"{link}&access_token={apiKey}";
                Console.WriteLine(url);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                return $"error requesting api / Message {e.Message}";
            }
        }
    }
}
