using Catnamespace;

public class CreateCatObject {

    private static Random rnd = new Random();

    public static Cat createCat() {

        // create cat
        Cat cat = new Cat();

        // cat type
        cat.Rasse = getRandomCatType();
        Console.WriteLine("Cat type: " + cat.Rasse.RassenName);

        // cat name
        cat.Name = getRandomCatName();
        Console.WriteLine("Cat name: " + cat.Name);

        // cat color
        cat.Farbe = getRandomCatColor(cat);
        Console.WriteLine("Cat color: " + cat.Farbe);

        // cat birthday
        cat.Geburtstag = getRandomCatBirthday();
        Console.WriteLine("Cat birthday: " + cat.Geburtstag);

        // cat environment
        cat.Umgebung = getRandomEnvironment();
        Console.WriteLine("Cat environment: " + cat.Umgebung);

        // cat weight
        cat.Gewicht = rnd.Next(500, 12000);
        Console.WriteLine("Cat weight: " + cat.Gewicht);

        // cat castrated
        cat.Kastriert = rnd.Next(0, 2) == 1;
        Console.WriteLine("Cat castrated: " + cat.Kastriert);

        // cat personality
        cat.Persönlichkeit = getRandomCatPersonality();
        Console.WriteLine("Cat personality: " + cat.Persönlichkeit);

        // cat beginndatum
        //cat.Beginndatum = DateTime.Today.AddDays(-rnd.Next(365));
        //Console.WriteLine("Cat beginndatum: " + cat.Beginndatum);

        // cat enddatum
        //cat.Enddatum = DateTime.Today.AddDays(rnd.Next(365));
        //Console.WriteLine("Cat enddatum: " + cat.Enddatum);

        // cat deckung
        cat.Deckung = rnd.Next(0, 100)*1000;
        Console.WriteLine("Cat deckung: " + cat.Deckung);

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
            new CatBreed("Siamese", 7000, 14, 2),
            new CatBreed("Perser", 7000, 15, 3),
            new CatBreed("Bengal", 6000, 13, 4),
            new CatBreed("Maine Coon", 10000, 14, 2),
            new CatBreed("Sphynx", 6000, 11, 5),
            new CatBreed("Scottish Fold", 6000, 14, 6),
            new CatBreed("British Shorthair", 6000, 14, 2),
            new CatBreed("British Shorthair", 5000, 14, 4),
            new CatBreed("Ragdoll", 7000, 14, 3)
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
                colors = new string[] {"Weiß", "Schildplatt", "Schwarz"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Bengal":
                colors = new string[] {"Braun", "Schildplatt", "Marmor"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Maine Coon":
                colors = new string[] {"Grau", "Braun", "Weiß"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Sphynx":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme", "Weiß", "Schildplatt", "Schwarz", "Braun", "Marmor", "Grau", "Zimt", "Rot"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Scottish Fold":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme", "Weiß", "Schildplatt", "Schwarz", "Braun", "Marmor", "Grau", "Zimt", "Rot"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "British Shorthair":
                colors = new string[] {"Seal", "Blau", "Lilac", "Creme", "Weiß", "Schildplatt", "Schwarz", "Braun", "Marmor", "Grau", "Zimt", "Rot"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Abyssinian":
                colors = new string[] {"Rot", "Schildplatt", "Zimt"};
                color = colors[rnd.Next(colors.Length)];
                break;
            case "Ragdoll":            
                colors = new string[] {"Blau", "Seal", "Lilac", "Schildplatt"};
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

}