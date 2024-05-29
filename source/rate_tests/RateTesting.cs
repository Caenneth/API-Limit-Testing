using Catnamespace;
using Customernamespace; 

namespace Rate_Tests
{
    class RateTesting 
    {
        public static async Task CalculateRate(bool printAllInsuranceData, Customer customer, Cat cat)        
        {
            Console.WriteLine($"Deckung: {cat.Deckung}");

            Rate_Calculation_API_Request_Azure apiRequestAzure = new Rate_Calculation_API_Request_Azure();
            await apiRequestAzure.SendRequest(cat.Deckung, cat.Rasse.RassenName, cat.Farbe, cat.Geburtstag, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, customer.Postleitzahl);
            Rate_Calculation_API_Request_AWS apiRequestAWS = new Rate_Calculation_API_Request_AWS();
            await apiRequestAWS.SendRequest(cat.Deckung, cat.Rasse.RassenName, cat.Farbe, cat.Geburtstag, cat.Kastriert, cat.Persönlichkeit, cat.Umgebung, cat.Gewicht, customer.Postleitzahl);

            double grundkosten = BerechneGrundkosten(cat);
            double prozentSatz = BerechneProzentsatz(customer, cat);
            double aufschlag = BerechneAufschlag(cat);
            if (printAllInsuranceData) {
                Console.WriteLine($"Grundkosten: {grundkosten}");
                Console.WriteLine($"ProzentSatz: {prozentSatz}");
                Console.WriteLine($"Aufschlag: {aufschlag}");
            }

            double endkosten = Math.Round((grundkosten * prozentSatz) + aufschlag, 2);
            Console.WriteLine($"Gesamtpreis: {endkosten}");
        }

        private static double BerechneAufschlag(Cat cat)
        {
            int aufschlag = 0;
            // aufschlag für gewicht über der norm
            // 1 kg = 1€
            if (cat.Rasse.MaxGewicht < cat.Gewicht) 
            { 
                int aufgerundetesGewicht = (int)Math.Ceiling((double)cat.Gewicht / 1000);
                aufschlag += (aufgerundetesGewicht - cat.Rasse.MaxGewicht / 1000) * 5; 
            }
            if (cat.Rasse.MinGewicht > cat.Gewicht) 
            { 
                int abgerundetesGewicht = (int)Math.Floor((double)cat.Gewicht / 1000);
                aufschlag += (cat.Rasse.MinGewicht / 1000 - abgerundetesGewicht) * 5; 
            }
            // aufschlag für kastriert
            // wenn nicht kastriert dann 5€ aufschlag
            if (!cat.Kastriert) { aufschlag += 5; }

            // aufschlag für krankheitswahrscheinlichkeit
            // Pro Wahrscheinlichkeit = 1€
            aufschlag += cat.Rasse.Krankheitsanfälligkeit;
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

            prozentSatz = Math.Round(prozentSatz, 2);
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
            return grundkosten;
        }
    }
}