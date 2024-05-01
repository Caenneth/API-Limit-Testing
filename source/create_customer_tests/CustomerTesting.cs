using Catnamespace;
using Customernamespace; 

namespace Customer_Tests
{
    class CustomerTesting  
    {
        public static async Task CreateContract(bool print, Customer customer, Cat cat)        
        {
            Create_Customer_API_Request_Azure apiRequestAzure = new Create_Customer_API_Request_Azure();
            await apiRequestAzure.SendRequest(customer.Email, customer.Vorname, customer.Nachname, customer.Titel, customer.Geburtsdatum, customer.SV_Nummer, customer.SteuerID, customer.Straße, customer.Hausnummer, customer.Postleitzahl, customer.Stadt, customer.IBAN, customer.BIC, customer.Vorname + " " + customer.Nachname, cat.Beginndatum, cat.Enddatum, cat.Deckung, cat.Name, cat.Rasse.RassenName, cat.Farbe, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht);
            //Create_Customer_API_Request_Azure apiRequestAWS = new Create_Customer_API_Request_Azure();
            //await apiRequestAWS.SendRequest();

        }
    }
}