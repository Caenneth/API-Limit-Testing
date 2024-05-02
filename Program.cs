using Rate_Tests;
using Catnamespace;
using Customernamespace;
using Customer_Tests;
using System.Diagnostics;
using System.IO;

public class MainClass {
    public static async Task Main() {
        Console.WriteLine("Started Testing, please wait ...");
        const int amount = 100;
        var customers = new List<Customer>(amount);
        var cats = new List<Cat>(amount);
        var printExtraInfo = false;

        for (int i = 0; i < amount; i++) {
            var customer = CreateCustomerObject.CreateCustomer(printExtraInfo);
            customers.Add(customer);
            var cat = CreateCatObject.CreateCat(printExtraInfo);
            cats.Add(cat);
        }

        /*for (int i = 0; i < amount; i++) {
            Console.WriteLine($"Test {i + 1} von {amount}");
            await RateTesting.CalculateRate(printExtraInfo, customers[i], cats[i]);
            Console.WriteLine("-------------------------------------------------");
        }*/

        Stopwatch stopwatch1 = Stopwatch.StartNew();
        using (StreamWriter writer = new StreamWriter("output.txt")) {
            for (int i = 0; i < amount; i++) {
                //Console.WriteLine($"Test {i + 1} von {amount}");
                writer.WriteLine($"Test {i + 1} von {amount}");
                Stopwatch stopwatch2 = Stopwatch.StartNew(); // Starten der Stoppuhr
                await CustomerTesting.CreateContract(printExtraInfo, customers[i], cats[i], writer);
                stopwatch2.Stop(); // Stoppen der Stoppuhr
                //Console.WriteLine($"Dauer der API-Anfrage: {stopwatch.ElapsedMilliseconds} ms"); // Ausgabe der verstrichenen Zeit in Millisekunden
                //Console.WriteLine("-------------------------------------------------");
                writer.WriteLine($"Dauer der API-Anfrage: {stopwatch2.ElapsedMilliseconds} ms"); // Schreiben der verstrichenen Zeit in Millisekunden in die Datei
                writer.WriteLine("-------------------------------------------------");
            }
            stopwatch1.Stop();
            writer.WriteLine($"Dauer der {amount} API-Requests: {stopwatch1.ElapsedMilliseconds} ms");
        }
        Console.WriteLine("Tests Completed.");
    }
}