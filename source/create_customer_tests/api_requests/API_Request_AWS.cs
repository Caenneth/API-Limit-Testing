using System.Text;
using System.Text.Json;

public class Create_Customer_API_Request_AWS {
    public async Task SendRequest(string Email, string FirstName, string LastName, string Title, string BirthDate, string SocialSecurityNumber, string TaxId, string Street, string HouseNumber, int ZipCode, string City, string Iban, string Bic, string Name, string StartDate, string EndDate, int Coverage, string CatName, string Breed, string Color, bool Neutered, string Personality, string Environemnt, int Weight, StreamWriter writer)
    {
        //Console.WriteLine("Sending request to AWS API");
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(1000)
        };

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

        var response = await client.PostAsync("https://w7gl0flz6e.execute-api.eu-central-1.amazonaws.com/Stage/apply", content);
        var responseString = await response.Content.ReadAsStringAsync();
        writer.WriteLine($"AWS Data: {responseString}");
        //Console.WriteLine("AWS Data: " + responseString);
        return;
    }
}