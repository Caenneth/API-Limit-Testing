using Catnamespace;
using Customernamespace;
using System.Diagnostics;

namespace Customer_Tests
{
    class CustomerTesting  
    {
        public static async Task QueueTests(int amountOfTests, bool printAPIResponse, List<Cat> cats, List<Customer> customers, bool azureQueueTests, bool awsQueueTests) 
        {
            string timestamp = DateTime.Now.ToString("ddMMyyyy-HHmmss");

            if (azureQueueTests)
            {
                Directory.CreateDirectory($"./outputs/azure");
                using (StreamWriter writer = new StreamWriter($"./outputs/azure/output_{timestamp}.txt")) 
                {
                    Stopwatch stopwatchAzure = Stopwatch.StartNew();
                    for (int i = 0; i < amountOfTests; i++) 
                    {
                        writer.WriteLine($"Azure Test {i + 1} von {amountOfTests}, Zeitstempel: {DateTime.Now}");

                        Stopwatch stopwatch2 = Stopwatch.StartNew(); 
                        await AzureCreateContract(printAPIResponse, customers[i], cats[i], writer);
                        stopwatch2.Stop(); 

                        writer.WriteLine($"Dauer der Azure API-Anfrage: {stopwatch2.ElapsedMilliseconds} ms"); 
                        writer.WriteLine("-------------------------------------------------");
                    }
                    stopwatchAzure.Stop();
                    writer.WriteLine($"Dauer der {amountOfTests} Azure API-Requests: {stopwatchAzure.ElapsedMilliseconds} ms");
                }
                Graph.CreateGraph("azure",timestamp);
            }

            if (awsQueueTests)
            {
                Directory.CreateDirectory($"./outputs/aws");
                using (StreamWriter writer = new StreamWriter($"./outputs/aws/output_{timestamp}.txt")) 
                {
                    Stopwatch stopwatchAWS = Stopwatch.StartNew();
                    for (int i = 0; i < amountOfTests; i++) 
                    {
                        writer.WriteLine($"AWS Test {i + 1} von {amountOfTests}, Zeitstempel: {DateTime.Now}");

                        Stopwatch stopwatch2 = Stopwatch.StartNew(); 
                        await AWSCreateContract(printAPIResponse, customers[i], cats[i], writer);
                        stopwatch2.Stop(); 

                        writer.WriteLine($"Dauer der AWS API-Anfrage: {stopwatch2.ElapsedMilliseconds} ms"); 
                        writer.WriteLine("-------------------------------------------------");
                    }
                    stopwatchAWS.Stop();
                    writer.WriteLine($"Dauer der {amountOfTests} AWS API-Requests: {stopwatchAWS.ElapsedMilliseconds} ms");
                }
                Graph.CreateGraph("aws", timestamp);
            }
            
            
        }
        public static async Task AzureCreateContract(bool print, Customer customer, Cat cat, StreamWriter writer)        
        {
            Create_Customer_API_Request_Azure apiRequestAzure = new Create_Customer_API_Request_Azure();
            await apiRequestAzure.SendRequest(customer.Email, customer.Vorname, customer.Nachname, customer.Titel, customer.Geburtsdatum, customer.SV_Nummer, customer.SteuerID, customer.Straße, customer.Hausnummer, customer.Postleitzahl, customer.Stadt, customer.IBAN, customer.BIC, customer.Vorname + " " + customer.Nachname, cat.Beginndatum, cat.Enddatum, cat.Deckung, cat.Name, cat.Rasse.RassenName, cat.Farbe, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, writer);
        }

        public static async Task AWSCreateContract(bool print, Customer customer, Cat cat, StreamWriter writer)     
        {   
            Create_Customer_API_Request_AWS apiRequestAWS = new Create_Customer_API_Request_AWS();
            await apiRequestAWS.SendRequest(customer.Email, customer.Vorname, customer.Nachname, customer.Titel, customer.Geburtsdatum, customer.SV_Nummer, customer.SteuerID, customer.Straße, customer.Hausnummer, int.Parse(customer.Postleitzahl), customer.Stadt, customer.IBAN, customer.BIC, customer.Vorname + " " + customer.Nachname, cat.Beginndatum, cat.Enddatum, cat.Deckung, cat.Name, cat.Rasse.RassenName, cat.Farbe, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, writer);
        }
    }
}