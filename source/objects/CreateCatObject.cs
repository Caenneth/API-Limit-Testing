using Catnamespace;
using System.Text;

public class CreateCatObject {

    private static Random rnd = new Random();

    public static Cat CreateCat(bool printAllInsuranceData) 
    {
        var cat = new Cat
        {
            Rasse = getRandomCatType(),
            Name = getRandomCatName(),
            Geburtstag = getRandomCatBirthday(),
            Umgebung = getRandomEnvironment(),
            Gewicht = rnd.Next(500, 12000),
            Kastriert = rnd.Next(0, 2) == 1,
            Persönlichkeit = getRandomCatPersonality(),
            Deckung = rnd.Next(1, 50) * 1000
        };

        // cat color
        cat.Farbe = getRandomCatColor(cat);

        // cat age
        cat.Alter = DateTime.Today.Year - DateTime.Parse(cat.Geburtstag).Year;
        
        // cat startdatum
        cat.Beginndatum = GetRandomFutureStartDate();

        // cat enddatum
        cat.Enddatum = GetRandomFutureEndDate(cat.Beginndatum);

        if (printAllInsuranceData)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Katzenrasse: {cat.Rasse.RassenName}");
            sb.AppendLine($"Name: {cat.Name}");
            sb.AppendLine($"Farbe: {cat.Farbe}");
            sb.AppendLine($"Geburtstag: {cat.Geburtstag}");
            sb.AppendLine($"Ater: {cat.Alter}");
            sb.AppendLine($"Umgebung: {cat.Umgebung}");
            sb.AppendLine($"Gewicht: {cat.Gewicht}");
            sb.AppendLine($"Kastriert: {cat.Kastriert}");
            sb.AppendLine($"Persönlichkeit: {cat.Persönlichkeit}");
            sb.AppendLine($"Deckung: {cat.Deckung}");
            sb.AppendLine($"Startdatum: {cat.Beginndatum}");
            sb.AppendLine($"Enddatum: {cat.Enddatum}");
            Console.WriteLine(sb.ToString());
        }

        return cat;
    }

    public static string getRandomCatName() 
    {
        // string array of cat names
        string[] names = new string[] { "Whiskers", "Tom", "Sylvester", "Garfield", "Salem", "Simba", "Felix", "Socks", "Mittens", "Tigger", "Kitty", "Luna", "Chloe", "Lucy", "Cleo", "Angel", "Molly", "Jasper", "Oreo", "Pepper", "Boots", "Misty", "Shadow", "Ginger", "Milo", "Charlie", "Pumpkin", "Sophie", "Max", "Princess", "Sam", "Missy", "Smokey", "Maggie", "Bella", "Tiger", "Lily", "Jack", "Lucky", "Zoe", "Coco", "Rocky", "Muffin", "Daisy", "Simon", "Baby", "Fiona", "Furball", "Oliver", "Peanut", "Midnight", "Sasha", "Bandit", "Boo"};
        return names[rnd.Next(0, names.Length)];
    }

    public static CatBreed getRandomCatType()
    {
        CatBreed[] catBreeds = 
        {
            new CatBreed("Siamese", 7000, 4000, 11, 2),
            new CatBreed("Perser", 7000, 4000, 12, 3),
            new CatBreed("Bengal", 6000, 4000, 12, 4),
            new CatBreed("Maine Coon", 10000, 5000, 11, 2),
            new CatBreed("Sphynx", 6000, 4000, 9, 5),
            new CatBreed("Scottish Fold", 6000, 4000, 11, 6),
            new CatBreed("British Shorthair", 6000, 4000, 11, 2),
            new CatBreed("Abyssinian", 5000, 3000, 11, 4),
            new CatBreed("Ragdoll", 7000, 4000, 11, 3)
        };
        int index = rnd.Next(catBreeds.Length);
        return catBreeds[index];
    }

    public static string getRandomCatColor(Cat cat)
    {
        string color = "";
        string[] colors;

        switch (cat.Rasse.RassenName)
        {
            case "Siamese":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Perser":
                colors = new string[] {"Weiß", "Schildpatt", "Schwarz"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Bengal":
                colors = new string[] {"Braun", "Schildpatt", "Marmor"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Maine Coon":
                colors = new string[] {"Grau", "Braun", "Weiß"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Sphynx":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme", "Weiß", "Schildpatt", "Schwarz", "Braun", "Marmor", "Grau", "Zimt", "Rot"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Scottish Fold":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme", "Weiß", "Schildpatt", "Schwarz", "Braun", "Marmor", "Grau", "Zimt", "Rot"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "British Shorthair":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme", "Weiß", "Schildpatt", "Schwarz", "Braun", "Marmor", "Grau", "Zimt", "Rot"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Abyssinian":
                colors = new string[] {"Rot", "Schildpatt", "Zimt"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Ragdoll":            
                colors = new string[] {"Blau", "Seal", "Lilac", "Schildpatt"};
                color = colors[rnd.Next(colors.Length)];
                break;
        }
        return color;
    }

    public static string getRandomCatBirthday()
    {
        int daysIn20Years = 20 * 365; // Anzahl der Tage in 20 Jahren
        Random rnd = new Random(); // Erstellt ein neues Random-Objekt
        int randomDays = rnd.Next(daysIn20Years); // Zufällige Anzahl von Tagen innerhalb der letzten 20 Jahre
        DateTime birthday = DateTime.Today.AddDays(-randomDays); // Zieht die zufällige Anzahl von Tagen vom heutigen Datum ab
        return birthday.ToString("yyyy-MM-dd"); // Konvertiert das DateTime-Objekt in einen String im Format "yyyy-MM-dd"
    }

    public static string getRandomEnvironment()
    {
        string[] environments = new string[] {"Drinnen", "Draußen"};
        int index = rnd.Next(environments.Length);
        return environments[index];
    }

    public static string getRandomCatPersonality()
    {
        //string[] personalities = new string[] {"Spielerisch", "Anhänglich"};
        string[] personalities = new string[] {"Anhänglich"};
        int index = rnd.Next(personalities.Length);
        return personalities[index];
    }   

    public static string GetRandomFutureStartDate()
    {
        Random rand = new Random();
        DateTime today = DateTime.Today;
        int futureMonth = rand.Next(today.Month + 1, 6);
        int day = rand.Next(2) == 0 ? 1 : 15;

        DateTime futureDate = new DateTime(today.Year, futureMonth, day);

        return futureDate.ToString("yyyy-MM-dd");
    }

    public static string GetRandomFutureEndDate(string startDate)
    {
        Random rand = new Random();
        DateTime today = DateTime.Today;

        // get the month of the start date
        int startMonth = DateTime.Parse(startDate).Month;
        // füge 1 bis 6 Monate hinzu
        int futureMonth = rand.Next(startMonth + 1, startMonth + 7);
        // wenn monat keine 31 tage hat erhöhe den monat um 1
        if (futureMonth == 2 || futureMonth == 4 || futureMonth == 6 || futureMonth == 9 || futureMonth == 11)
        {
            futureMonth++;
        }
        // setze tag auf den 14 oder 31 des Monats
        int day = rand.Next(2) == 0 ? 14 : 31;

        DateTime futureDate = new DateTime(today.Year, futureMonth, day);

        return futureDate.ToString("yyyy-MM-dd");
    }
}