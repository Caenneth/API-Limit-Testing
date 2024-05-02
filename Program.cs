using Rate_Tests;
using Catnamespace;
using Customernamespace;
using Customer_Tests;

public class MainClass {
    public static async Task Main() {
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

        for (int i = 0; i < amount; i++) {
            Console.WriteLine($"Test {i + 1} von {amount}");
            await CustomerTesting.CreateContract(printExtraInfo, customers[i], cats[i]);
            Console.WriteLine("-------------------------------------------------");
        }
    }
}