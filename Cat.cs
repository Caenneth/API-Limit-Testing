using Catnamespace;

namespace Catnamespace
{
    public class Cat 
    {
        public string Beginndatum { get; set; }
        public string Enddatum { get; set; }
        public int Deckung { get; set; }
        public string Name { get; set; }
        public CatBreed Rasse { get; set; }
        public string Farbe { get; set; }
        public string Geburtstag { get; set; }
        public int Alter { get; set; }
        public string Persönlichkeit { get; set; }
        public string Umgebung { get; set; }
        public int Gewicht { get; set; }
        public bool Kastriert { get; set; }

        public Cat() {}
    }

    public class CatBreed 
    {
        public string RassenName { get; set; }
        public int MaxGewicht { get; set; }
        public int MinGewicht { get; set; }
        public int Durchschnittsalter { get; set; }
        public int Krankheitsanfälligkeit { get; set; }

        public CatBreed(string rassenName, int maxGewicht, int minGewicht, int durchschnittsalter, int krankheitsanfälligkeit) 
        {
            RassenName = rassenName;
            MaxGewicht = maxGewicht;
            Durchschnittsalter = durchschnittsalter;
            Krankheitsanfälligkeit = krankheitsanfälligkeit;
            MinGewicht = minGewicht;
        }
    }
}

