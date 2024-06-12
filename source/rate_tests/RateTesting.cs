using Catnamespace;
using Customernamespace; 
using System.Diagnostics;

namespace Rate_Tests
{
    class RateTesting 
    {
        public static async Task CalculateRate(bool printAllInsuranceData, List<Customer> customers, List<Cat> cats, bool azureRateTest, bool awsRateTest, int amountOfTests)        
        {
            //Console.WriteLine($"Deckung: {cat.Deckung}");

            string timestamp = DateTime.Now.ToString("ddMMyyyy-HHmmss");

            if (azureRateTest)
            {
                using (StreamWriter writer = new StreamWriter($"./outputs/azure/rate/output_{timestamp}.txt")) 
                {
                    Stopwatch stopwatchAzure = Stopwatch.StartNew();
                    for (int i = 0; i < amountOfTests; i++) 
                    {
                        writer.WriteLine($"Azure Test {i + 1} von {amountOfTests}, Zeitstempel: {DateTime.Now}");

                        Stopwatch stopwatch2 = Stopwatch.StartNew(); 
                        
                        Rate_Calculation_API_Request_Azure apiRequestAzure = new Rate_Calculation_API_Request_Azure();
                        await apiRequestAzure.SendRequest(cats[i].Deckung, cats[i].Rasse.RassenName, cats[i].Farbe, cats[i].Geburtstag, cats[i].Kastriert, cats[i].Persönlichkeit, cats[i].Umgebung, cats[i].Gewicht, customers[i].Postleitzahl, writer);
                        
                        stopwatch2.Stop(); 

                        writer.WriteLine($"Dauer der Azure API-Anfrage: {stopwatch2.ElapsedMilliseconds} ms"); 
                        writer.WriteLine("-------------------------------------------------");
                    }
                    stopwatchAzure.Stop();
                    writer.WriteLine($"Dauer der {amountOfTests} Azure API-Requests: {stopwatchAzure.ElapsedMilliseconds} ms");
                }
                Graph.CreateGraph("azure/rate",timestamp);
            }

            if (awsRateTest)
            {
                using (StreamWriter writer = new StreamWriter($"./outputs/aws/rate/output_{timestamp}.txt")) 
                {
                    Stopwatch stopwatchAWS = Stopwatch.StartNew();
                    for (int i = 0; i < amountOfTests; i++) 
                    {
                        writer.WriteLine($"AWS Test {i + 1} von {amountOfTests}, Zeitstempel: {DateTime.Now}");

                        Stopwatch stopwatch2 = Stopwatch.StartNew(); 
                        
                        Rate_Calculation_API_Request_AWS apiRequestAWS = new Rate_Calculation_API_Request_AWS();
                        await apiRequestAWS.SendRequest(cats[i].Deckung, cats[i].Rasse.RassenName, cats[i].Farbe, cats[i].Geburtstag, cats[i].Kastriert, cats[i].Persönlichkeit, cats[i].Umgebung, cats[i].Gewicht, customers[i].Postleitzahl, writer);
            
                        stopwatch2.Stop(); 

                        writer.WriteLine($"Dauer der AWS API-Anfrage: {stopwatch2.ElapsedMilliseconds} ms"); 
                        writer.WriteLine("-------------------------------------------------");
                    }
                    stopwatchAWS.Stop();
                    writer.WriteLine($"Dauer der {amountOfTests} AWS API-Requests: {stopwatchAWS.ElapsedMilliseconds} ms");
                }
                Graph.CreateGraph("aws/rate",timestamp);
            }

            return;
            /*
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
            */
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