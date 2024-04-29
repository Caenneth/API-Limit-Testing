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

        // berechne grundkosten
        double grundkosten = cat.Deckung/1000 * promillesatz;
        Console.WriteLine("Grundkosten: " + grundkosten);

        double prozentSatz = 0.0;
        // aufschlag für alter
        // TODO: Create basic cat data and then compare average age with age of cat
        if (cat.Alter < 2) {
            prozentSatz += 0.1;
        }
        if (cat.Rasse.Durchschnittsalter < cat.Alter)
        {
            prozentSatz += 0.2;
        }

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

        prozentSatz += 1;
        Math.Round(prozentSatz, 2);

        Console.WriteLine("ProzentSatz: " + prozentSatz);
        double prozentZuschlag = Math.Round(grundkosten * (prozentSatz), 2);
        Console.WriteLine("Grundkosten plus ProzentSatz: " + prozentZuschlag);

        int aufschlag = 0;
        // aufschlag für gewicht über der norm
        // TODO: Create basic cat data and then compare average weight with weight of cat
        if (cat.Rasse.Durchschnittsgewicht < cat.Gewicht)
        {
            int gewichtAufschlag = (cat.Gewicht - cat.Rasse.Durchschnittsgewicht)/1000;
            Console.WriteLine("Gewichtaufschlag: " + gewichtAufschlag);
            aufschlag += gewichtAufschlag; 
        }

        // aufschlag für kastriert
        if (cat.Kastriert) 
        {
            aufschlag += 5;
            Console.WriteLine("Kastriertaufschlag: " + 5);
        }

        // aufschlag für krankheitswahrscheinlichkeit
        Console.WriteLine("Krankheitsanfälligkeitsaufschlag: " + cat.Rasse.Krankheitsanfälligkeit);
        aufschlag += cat.Rasse.Krankheitsanfälligkeit;

        double endkosten = grundkosten + prozentZuschlag + aufschlag;
        Console.WriteLine("Gesamtpreis: " + endkosten);
    }

    public static async Task Main() {
        int amount = 1;
        await sendAPIRequest(amount);
    }
}