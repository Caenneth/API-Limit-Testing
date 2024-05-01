using System.Text;
using System.Text.Json;
using System.Net.Http;

public class Create_Customer_API_Request_AWS {
    
    public async Task SendRequest()
    {
        //Console.WriteLine("Sending request to Azure API");
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        var data = new 
        {

        };

        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var jsonData = JsonSerializer.Serialize(data, options);
        //Console.WriteLine(jsonData);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("", content);
        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Azure Data: " + responseString);
        return;
    }
}