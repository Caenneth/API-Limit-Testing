using Customernamespace;

public class CreateCustomerObject {

    private static Random rnd = new Random();

    public static Customer createCustomer() {
        // create customer
        Customer customer = new Customer();
        
        // vorname
        customer.Vorname = getRandomCustomerName();
        Console.WriteLine("Vorname: " + customer.Vorname);

        // nachname
        customer.Nachname = getRandomCustomerSurname();
        Console.WriteLine("Nachname: " + customer.Nachname);

        // straße
        customer.Straße = getRandomCustomerStraße();
        Console.WriteLine("Straße: " + customer.Straße);

        // hausnummer
        customer.Hausnummer = rnd.Next(1, 500).ToString();
        Console.WriteLine("Hausnummer: " + customer.Hausnummer);

        // postleitzahl
        int postleitzahl = rnd.Next(0, 50000);
        customer.Postleitzahl = postleitzahl.ToString("D5");
        Console.WriteLine("Postleitzahl: " + customer.Postleitzahl);


        // stadt
        customer.Stadt = getRandomCustomerStadt();
        Console.WriteLine("Stadt: " + customer.Stadt);

        // titel
        customer.Titel = getRandomCustomerTitel();
        Console.WriteLine("Titel: " + customer.Titel);

        // iban
        long part1 = (long)rnd.Next(0, int.MaxValue) << 32;
        long part2 = (long)rnd.Next(0, int.MaxValue);
        long randomNumber = part1 | part2;

        customer.IBAN = "DE22" + randomNumber.ToString("D18");
        Console.WriteLine("IBAN: " + customer.IBAN);

        // bic
        // random 4 length string
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string randomString = new string(Enumerable.Repeat(chars, 4)
        .Select(s => s[rnd.Next(s.Length)]).ToArray());
        customer.BIC = randomString + "DE" + rnd.Next(0, 100000).ToString("D5");
        Console.WriteLine("BIC: " + customer.BIC);

        // familienstatus
        customer.Familienstatus = getRandomCustomerStatus();
        Console.WriteLine("Familienstatus: " + customer.Familienstatus);

        // email
        // TODO: use non existing emails or use 1 email where all mails get send do
        //customer.Email = customer.Vorname + "." + customer.Nachname + "@gmail.com";
        //Console.WriteLine("Email: " + customer.Email);
        customer.Email = "finnwolters@web.de";

        // sv_nummer 
        // 8 ziffern + 1 letter + 3 ziffern
        return customer;
    }

    public static string getRandomCustomerName() {
        string[] names = new string[] {"Hans", "Peter", "Michael", "Thomas", "Andreas", "Stefan", "Christian", "Martin", "Klaus", "Frank", "Jürgen", "Uwe", "Wolfgang", "Bernd", "Jens", "Dirk", "Manfred", "Heinz", "Markus", "Oliver", "Ralf", "Alexander", "Matthias", "Jörg", "Holger", "Rainer", "Dieter", "Karl", "Günter", "Friedrich", "Erich", "Gerd", "Horst", "Werner", "Wilhelm", "Gerhard", "Kurt", "Herbert", "Helmut", "Walter", "Erwin", "Hermann", "Alfred"};
        int index = rnd.Next(names.Length);
        return names[index];
    }

    public static string getRandomCustomerSurname() {
        string[] surnames = new string[] {"Müller", "Schmidt", "Schneider", "Fischer", "Weber", "Meyer", "Wagner", "Becker", "Schulz", "Hoffmann", "Schäfer", "Koch", "Bauer", "Richter", "Klein", "Wolf", "Schröder", "Neumann", "Schwarz", "Zimmermann", "Braun", "Krüger", "Hofmann", "Hartmann", "Lange", "Schmitt", "Werner", "Schmitz", "Krause", "Meier", "Lehmann", "Schmid", "Schulze", "Maier", "Köhler", "Herrmann", "König", "Walter", "Mayer", "Huber", "Kaiser", "Fuchs", "Peters", "Lang", "Scholz", "Möller", "Weiß", "Jung", "Hahn", "Schubert", "Vogel", "Friedrich", "Günther", "Barth", "Lorenz", "Thiel", "Beck", "Berger", "Frank", "Albrecht", "Schramm", "Otto", "Bergmann", "Böhm", "Simon", "Voigt", "Sauer", "Arndt", "Ludwig", "Krämer", "Kramer", "Götz", "Kuhn", "Thomas", "Pohl", "Ziegler", "Schuster", "Eckert", "Witt", "Ullrich", "Heinrich", "Lutz", "Seidel", "Löffler", "Baumann", "Graf", "Schulte", "Dietrich", "Zeller", "Jakob", "Kühn", "Marx", "Stark", "Engel", "Horn", "Brandt", "Keller", "Wolff", "Schreiber", "Voß", "Reuter", "Beyer", "Schultze", "Schwartz", "Ulrich", "Reinhardt", "Gross", "Mayr", "Martin", "Schreiner", "Kruse", "Kraft", "Vetter", "J"};
        int index = rnd.Next(surnames.Length);
        return surnames[index];
    }

    public static string getRandomCustomerStraße() {
        string[] streets = new string[] {"Hauptstraße", "Bahnhofstraße", "Berliner Straße", "Schulstraße", "Kirchstraße", "Goethestraße", "Friedrichstraße", "Mühlenstraße", "Schillerstraße", "Lindenstraße", "Bergstraße", "Marktstraße", "Kirchplatz", "Rathausstraße", "Poststraße", "Hofstraße", "Karl-Marx-Straße", "Schloßstraße", "Hermannstraße", "Königstraße", "Schulweg", "Am Markt", "Bismarckstraße", "Schulberg", "Gartenstraße", "Schloßberg", "Schulze-Delitzsch-Straße", "Schloßplatz", "Schulplatz"};
        int index = rnd.Next(streets.Length);
        return streets[index];
    }

    public static string getRandomCustomerStadt() {
        string[] cities = new string[] {"Berlin", "Hamburg", "München", "Köln", "Frankfurt am Main", "Stuttgart", "Düsseldorf", "Dortmund", "Essen", "Leipzig", "Bremen", "Dresden", "Hannover", "Nürnberg", "Duisburg", "Bochum", "Wuppertal", "Bielefeld", "Bonn", "Münster", "Karlsruhe", "Mannheim", "Augsburg", "Wiesbaden", "Gelsenkirchen", "Mönchengladbach", "Braunschweig", "Chemnitz", "Kiel", "Aachen", "Halle (Saale)", "Magdeburg", "Freiburg im Breisgau", "Krefeld", "Lübeck", "Oberhausen", "Erfurt", "Mainz", "Rostock", "Kassel", "Hagen", "Saarbrücken", "Hamm", "Mülheim an der Ruhr", "Herne", "Ludwigshafen am Rhein", "Osnabrück", "Solingen", "Leverkusen", "Oldenburg", "Neuss", "Potsdam", "Heidelberg", "Paderborn", "Darmstadt", "Würzburg", "Regensburg", "Ingolstadt", "Heilbronn", "Ulm", "Wolfsburg", "Göttingen", "Reutlingen", "Koblenz", "Bremerhaven", "Jena", "Trier", "Erlangen", "Moers", "Cottbus", "Hildesheim", "Siegen", "Salzgitter", "Kaiserslautern", "Witten", "Gütersloh", "Iserlohn", "Schwäbisch Gmünd", "Hattingen", "Düren", "Ratingen", "Landshut", "Troisdorf", "Gummersbach", "Neumünster", "Viersen", "Lüneburg", "Flensburg", "Wilhelmshaven", "Brandenburg an der Havel", "Offenbach am Main", "Fulda", "Celle", "Lippstadt", "Gießen", "Speyer", "Baden-Baden", "Aschaffenburg", "Schweinfurt", "Neubrandenburg", "Passau", "Friedrichshafen", "Stralsund", "Goslar", "Lörrach", "Ravensburg", "Kempten (Allgäu)", "Bad Homburg vor der Höhe", "Lingen (Ems)", "Sindelfingen", "Langenfeld (Rheinland)", "Neu-Ulm", "Neustadt an der Weinstraße", "Grevenbroich", "Herford", "Elmshorn", "Stade", "Ahlen", "Bergheim", "Böblingen", "Rodgau", "Kerpen", "Frechen", "Filderstadt", "Schwerte", "Alsdorf", "Bietigheim-Bissingen", "Lahr/Schwarzwald", "Fellbach", "Nürtingen", "Worms", "Bruchsal", "Kirchheim unter Teck", "Rottenburg am Neckar", "Memmingen", "Bensheim", "Kornwestheim", "Schwabach", "Freising", "Friedberg (Hessen)", "Friedrichsdorf", "Weinheim", "Bad Vilbel", "Ettlingen", "Andernach", "Kehl", "Achim", "Bühl", "Ostfildern", "Emden", "Königswinter", "Kamp-Lintfort", "Leinfelden-Echterdingen", "Stuhr", "Hattersheim am Main", "Pulheim", "Goch", "Gaggenau", "Niederkassel", "Weyhe", "Wesseling", "Schorndorf", "Hennef (Sieg)", "Waltrop", "Bad Nauheim", "Bad Oeynhausen", "Biberach an der Riß", "Bramsche", "Bretten", "Burgdorf", "Burgwedel", "Büdingen", "Bühlertal", "Bünde", "Bürstadt", "Calw", "Coesfeld", "Datteln", "Deggendorf", "Delbrück"};
        int index = rnd.Next(cities.Length);
        return cities[index];
    }

    public static string getRandomCustomerTitel() 
    {
        string[] titles = new string[] {"Dr.", "Prof. Dr.", "Dr. Dr.", "Prof. Dr. Dr."};
        int index = rnd.Next(titles.Length);
        return titles[index];
    }

    public static string getRandomCustomerStatus() {
        string[] statuses = new string[] {"Ledig", "Verheiratet", "Geschieden", "Verwitwet"};
        int index = rnd.Next(statuses.Length);
        return statuses[index];
    }
}