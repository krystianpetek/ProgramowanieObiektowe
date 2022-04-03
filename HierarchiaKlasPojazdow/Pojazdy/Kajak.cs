using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow.Pojazdy
{
    internal class Kajak : Pojazd, IWodny
    {
        public Kajak(int wypornosc)
        {
            Wypornosc = wypornosc;
        }

        public override double Przyspieszenie => 5;
        public override double MaksymalnaPredkosc => 20;
        public int Wypornosc { get; init; }

        public override string ToString()
        {
            string czyPoruszaSie = ((CzyPoruszaSie) ? $"Tak\n{"Aktualna prędkość: ",-30}{Predkosc} {JednostkaPredkosci}" : "Nie");
            string czyPojazdMaSilnik = (this is ISilnik ? $"Tak" : "Nie");
            string srodowiska = "";
            for (int i = 0; i < dostepneSrodowisko.Count; i++)
            {
                if (i == dostepneSrodowisko.Count - 1)
                {
                    srodowiska += $"{dostepneSrodowisko[i]}";
                    break;
                }
                srodowiska += $"{dostepneSrodowisko[i]}, ";
            }
            return $"\nInformacje o pojezdzie: \n" +
                $"{"Typ pojazdu: ",-30}{GetType().Name}\n" +
                $"{"Możliwe środowiska pojazdu: ",-30}{srodowiska}\n" +
                $"{"Aktualne środowisko: ",-30}{aktualneSrodowisko}\n" +
                $"{"Predkość minimalna: ",-30}{ MinimalnaPredkosc} {JednostkaPredkosci}\n" +
                $"{"Predkość maksymalna: ",-30}{ MaksymalnaPredkosc} {JednostkaPredkosci}\n" +
                $"{"Czy pojazd porusza się: ",-30}{czyPoruszaSie}\n" +
                $"{"Pojazd silnikowy: ",-30}{czyPojazdMaSilnik}\n";
        }
    }
}