using Catnamespace;
using Customernamespace;
public class InsuranceCreation 
{
    public static async Task<(List<Cat>, List<Customer>)> CreateTestInsurances(int amount, bool printAllInsuranceData)
    {
        var customers = new List<Customer>(amount);
        var cats = new List<Cat>(amount);
        for (int i = 0; i < amount; i++)
        {
            var customer = CreateCustomerObject.CreateCustomer(printAllInsuranceData);
            customers.Add(customer);
            var cat = CreateCatObject.CreateCat(printAllInsuranceData);
            cats.Add(cat);
        }
        return (cats, customers);
    }
}