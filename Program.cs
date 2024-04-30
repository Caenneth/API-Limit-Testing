using System;
using System.Runtime.CompilerServices;
using Catnamespace;
using Customernamespace;

public class Program {

    public static async Task SendAPIRequest(int amount)
    {
        Customer customer = CreateCustomerObject.CreateCustomer(false);
        Cat cat = CreateCatObject.CreateCat(false);

        API_Request_Azure apiRequestAzure = new API_Request_Azure();
        await apiRequestAzure.SendRequest(cat.Deckung, cat.Rasse.RassenName, cat.Farbe, cat.Geburtstag, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, int.Parse(customer.Postleitzahl));
        API_Request_AWS apiRequestAWS = new API_Request_AWS();
        await apiRequestAWS.SendRequest(cat.Deckung, cat.Rasse.RassenName, cat.Farbe, cat.Geburtstag, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, int.Parse(customer.Postleitzahl));

        double grundkosten = BerechneGrundkosten(cat);
        double prozentSatz = BerechneProzentsatz(customer, cat);
        double aufschlag = BerechneAufschlag(cat);

        double endkosten = (grundkosten * prozentSatz) + aufschlag;
        Console.WriteLine("Gesamtpreis: " + endkosten);
    }

    private static double BerechneAufschlag(Cat cat)
    {
        int aufschlag = 0;
        // aufschlag für gewicht über der norm
        // 1 kg = 1€
        if (cat.Rasse.Durchschnittsgewicht < cat.Gewicht) { aufschlag += (cat.Gewicht - cat.Rasse.Durchschnittsgewicht) / 1000; }

        // aufschlag für kastriert
        // wenn nicht kastriert dann 5€ aufschlag
        if (!cat.Kastriert) { aufschlag += 5; }

        // aufschlag für krankheitswahrscheinlichkeit
        // Pro Wahrscheinlichkeit = 1€
        aufschlag += cat.Rasse.Krankheitsanfälligkeit;
        Console.WriteLine("Aufschlag: " + aufschlag);
        return aufschlag;
    }

    private static double BerechneProzentsatz(Customer customer, Cat cat)
    {
        double prozentSatz = 1.0;
        // aufschlag für alter
        // wenn katze jünger als 2 jahre dann 10% aufschlag
        if (cat.Alter < 2) { prozentSatz += 0.1; }
        // wenn katze älter als durchschnittsalter der rasse dann 20% aufschlag
        if (cat.Rasse.Durchschnittsalter < cat.Alter) { prozentSatz += 0.2; }

        // aufschlag für umgebung
        // wenn katze draußen lebt dann 10% aufschlag
        if (cat.Umgebung == "Draußen") { prozentSatz += 0.1; }

        // aufschlag für postleitzahl
        // wenn postleitzahl mit 0 oder 1 beginnt dann 5% aufschlag
        if (customer.Postleitzahl[0] == '0' || customer.Postleitzahl[0] == '1') { prozentSatz += 0.05; }

        Math.Round(prozentSatz, 2);
        Console.WriteLine("ProzentSatz: " + prozentSatz);
        return prozentSatz;
    }

    private static double BerechneGrundkosten(Cat cat)
    {
        // promillesatz
        double promillesatz = 1.5;
        if (cat.Farbe == "Schwarz")
        {
            promillesatz += 0.5;
        }

        // berechne grundkosten
        double grundkosten = cat.Deckung / 1000 * promillesatz;
        Console.WriteLine("Grundkosten: " + grundkosten);
        return grundkosten;
    }

    public static async Task Main() {
        int amount = 1;
        await SendAPIRequest(amount);
    }


}