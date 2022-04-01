namespace musearcherApi
{
    public class httpClient
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Get(string link)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{link}&access_token={Environment.GetEnvironmentVariable("ApiKey")}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
