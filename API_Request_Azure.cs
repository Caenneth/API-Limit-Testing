using System.Text;
using System.Text.Json;
using System.Net.Http;

public class API_Request_Azure {
    public async Task SendRequest(int coverage, string breed, string color, string birthDate, bool neutered, string personality, string environment, int weight, int zipCode)
    {
        Console.WriteLine("Sending request to Azure API");
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        var data = new 
        {
            coverage = coverage,
            breed = breed,
            color = color,
            birthDate = birthDate,
            neutered = neutered,
            personality = personality,
            environment = environment,
            weight = weight,
            zipCode = zipCode
        };

        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var jsonData = JsonSerializer.Serialize(data, options);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://meowmedazure-apim.azure-api.net/customer/rate", content);
        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
        return;
    }
}