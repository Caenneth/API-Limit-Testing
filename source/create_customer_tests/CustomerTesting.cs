using Catnamespace;
using Customernamespace; 

namespace Customer_Tests
{
    class CustomerTesting  
    {
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