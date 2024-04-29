using System;
using System.Runtime.CompilerServices;
using Catnamespace;
using Customernamespace;

public class Program {

    public static async Task sendAPIRequest(int amount)
    {
        Customer customer = CreateCustomerObject.createCustomer();
        Cat cat = CreateCatObject.createCat();

        API_Request_Azure apiRequestAzure = new API_Request_Azure();
        await apiRequestAzure.SendRequest(cat.Deckung, cat.Rasse.RassenName, cat.Farbe, cat.Geburtstag, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, int.Parse(customer.Postleitzahl));
        API_Request_AWS apiRequestAWS = new API_Request_AWS();
        //await apiRequestAWS.SendRequest(cat.Deckung, cat.Rasse, cat.Farbe, cat.Geburtstag, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, int.Parse(customer.Postleitzahl));

        // promillesatz
        double promillesatz = 1.5;
        if (cat.Farbe == "Schwarz") 
        {
            promillesatz += 0.5;
        }

        double grundkosten = cat.Deckung * (promillesatz/1000);
        Console.WriteLine("Grundkosten: " + grundkosten);

        double prozentSatz = 0.0;
        // aufschlag für alter
        // TODO: Create basic cat data and then compare average age with age of cat

        // aufschlag für umgebung
        if (cat.Umgebung == "Draußen") 
        {
            prozentSatz += 0.1;
        }

        // aufschlag für postleitzahl
        // wenn postleitzahl mit 0 oder 1 beginnt dann 5% aufschlag

        if (customer.Postleitzahl[0] == '0' || customer.Postleitzahl[0] == '1') 
        {
            prozentSatz += 0.05;
        }

        Console.WriteLine("Promillesatz: " + promillesatz);

        double gkpz = grundkosten * (prozentSatz+1);


        // aufschlag für gewicht über der norm
        // TODO: Create basic cat data and then compare average weight with weight of cat

        // aufschlag für kastriert
        // TODO: Check if price is added when cat is castrated or when it is not castrated
        if (cat.Kastriert) 
        {
            prozentSatz += 0.1;
        }

        // aufschlag für krankheitswahrscheinlichkeit
    }

    public static async Task Main() {
        int amount = 1;
        await sendAPIRequest(amount);
    }
}