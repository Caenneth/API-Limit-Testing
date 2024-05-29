using Rate_Tests;
using Catnamespace;
using Customernamespace;
using Customer_Tests;
using System.Diagnostics;
using System.Runtime;
using Microsoft.VisualBasic;

public class MainClass {
    public static async Task Main() {
        // Set the amount of tests and if you want to do rate tests or queue tests
        const int amountOfTests = 10;
        const bool doRateTests = false;
        const bool doQueueTests = true;

        // Print extra data for debugging
        var printAllInsuranceData = false;
        var printAPIResponse = false;

        Console.WriteLine("Started Testing, please wait ...");
        var (cats, customers) = await InsuranceCreation.CreateTestInsurances(amountOfTests, printAllInsuranceData);
        if (doRateTests) 
        {
            await RateTests(amountOfTests, printAPIResponse, cats, customers);
        }
        if (doQueueTests) 
        {
            await QueueTests(amountOfTests, printAPIResponse, cats, customers);
        }
        Console.WriteLine("Tests Completed.");
        return;
    }
    public static async Task RateTests(int amountOfTests, bool printAPIResponse, List<Cat> cats, List<Customer> customers) 
    {
        for (int i = 0; i < amountOfTests; i++) {
            Console.WriteLine($"Test {i + 1} von {amountOfTests}");
            await RateTesting.CalculateRate(printAPIResponse, customers[i], cats[i]);
            Console.WriteLine("-------------------------------------------------");
        }
    }

    public static async Task QueueTests(int amountOfTests, bool printAPIResponse, List<Cat> cats, List<Customer> customers) {
        string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");

        Stopwatch stopwatch1 = Stopwatch.StartNew();
        using (StreamWriter writer = new StreamWriter($"outputs/output_{timestamp}.txt")) {
            for (int i = 0; i < amountOfTests; i++) {
                writer.WriteLine($"Test {i + 1} von {amountOfTests}, Zeitstempel: {DateTime.Now}");
                
                // Starten der Stoppuhr
                Stopwatch stopwatch2 = Stopwatch.StartNew(); 
                
                // Azure und AWS API-Requests
                //await CustomerTesting.AzureCreateContract(printAPIResponseToConsole, customers[i], cats[i], writer);
                await CustomerTesting.AWSCreateContract(printAPIResponse, customers[i], cats[i], writer);
                
                // Stoppen der Stoppuhr
                stopwatch2.Stop(); 

                // Schreiben der verstrichenen Zeit in Millisekunden in die Datei
                writer.WriteLine($"Dauer der API-Anfrage: {stopwatch2.ElapsedMilliseconds} ms"); 
                writer.WriteLine("-------------------------------------------------");
            }
            // Stoppen der Stoppuhr
            stopwatch1.Stop();
            // Schreiben der Gesamtzeit ans Ende der Datei
            writer.WriteLine($"Dauer der {amountOfTests} API-Requests: {stopwatch1.ElapsedMilliseconds} ms");
        }
        // Graph erstellen
        Graph.CreateGraph(timestamp);
    }
}



