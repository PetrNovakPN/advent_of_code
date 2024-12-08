using Newtonsoft.Json;

namespace aoc_lib.Utils;

public class AocHttpClient
{
    private const string BaseUrl = "https://adventofcode.com";
    
    public static async Task<string> GetAsync(string endpoint, string sessionKey)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cookie", $"session={sessionKey}");
        
        var requestUrl = $"{BaseUrl}{endpoint}";
        var response = await client.GetAsync(requestUrl);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}