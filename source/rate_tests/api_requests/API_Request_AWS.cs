using System.Text;
using System.Text.Json;
using System.Net.Http;

public class Rate_Calculation_API_Request_AWS {
    public async Task SendRequest(int coverage, string breed, string color, string birthDate, bool neutered, string personality, string environment, int weight, string zipCode, StreamWriter writer)
    {
        //Console.WriteLine("Sending request to Azure API");
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(1000)
        };

        
        int zC = int.Parse(zipCode);

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
            zipCode = zC
        };

        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var jsonData = JsonSerializer.Serialize(data, options);
        writer.WriteLine(jsonData);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://w7gl0flz6e.execute-api.eu-central-1.amazonaws.com/Stage/rate", content);
        var responseString = await response.Content.ReadAsStringAsync();
        writer.WriteLine("AWS Data: " + responseString);
        return;
    }
}