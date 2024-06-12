using System.Text;
using System.Text.Json;

public class Create_Customer_API_Request_Azure {
    public async Task SendRequest(string Email, string FirstName, string LastName, string Title, string BirthDate, string SocialSecurityNumber, string TaxId, string Street, string HouseNumber, string ZipCode, string City, string Iban, string Bic, string Name, string StartDate, string EndDate, int Coverage, string CatName, string Breed, string Color, bool Neutered, string Personality, string Environemnt, int Weight, StreamWriter writer)
    {
        //Console.WriteLine("Sending request to Azure API");
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(1000)
        };
        //var accessKey = "7b8ad6faf18b4b4db117e8fb75cc440d";
        //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", accessKey);

        var data = new 
        {
            customer = new 
            {
                email = Email,
                firstName = FirstName,
                lastName = LastName,
                title = Title,
                birthDate = BirthDate,
                socialSecurityNumber = SocialSecurityNumber,
                taxId = TaxId,
                address = new 
                {
                    street = Street,
                    houseNumber = HouseNumber,
                    zipCode = ZipCode,
                    city = City,
                },
                bankDetails = new 
                {
                    iban = Iban,
                    bic = Bic,
                    name = Name
                },
            },
            contract = new 
            {
                startDate = StartDate,
                endDate = EndDate,
                coverage = Coverage,
                catName = CatName,
                breed = Breed,
                color = Color,
                birthDate = BirthDate,
                neutered = Neutered,
                personality = Personality,
                environment = Environemnt,
                weight = Weight
            }
        };

        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var jsonData = JsonSerializer.Serialize(data, options);
        writer.WriteLine(jsonData);
        //Console.WriteLine(jsonData);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        // default function request
        var url = "https://meowmedazure-functions.azurewebsites.net/api/customer/apply?code=QjQ_X9KQiihpGMTSk_K1UGADajFTt_zYABMpI-IV9xobAzFuKs6KqA%3D%3D";
        var functionKey = "QjQ_X9KQiihpGMTSk_K1UGADajFTt_zYABMpI-IV9xobAzFuKs6KqA==";

        var response = await client.PostAsync(url, content);

        // APIM Request
        //var response = await client.PostAsync("https://meowmedazure-apim.azure-api.net/customer/apply", content);
        var responseString = await response.Content.ReadAsStringAsync();
        writer.WriteLine($"Azure Data: {responseString}");
        //Console.WriteLine("Azure Data: " + responseString);
        return;
    }
}