using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow.Pojazdy
{
    internal class Amfibia : Pojazd, ILadowy, IWodny, ISilnik
    {
        public Amfibia(double mocSilnika, int liczbaKol, int wypornosc) : base()
        {
            Silnik = RodzajSilnika.Diesel;
            MocSilnika = mocSilnika;
            LiczbaKol = liczbaKol;
            Wypornosc = wypornosc;
        }

        public int LiczbaKol { get; init; }
        public RodzajSilnika Silnik { get; init; }
        public double MocSilnika { get; init; }
        public int Wypornosc { get; init; }

        public override string ToString()
        {
            string czyPoruszaSie = ((CzyPoruszaSie) ? $"Tak\n{"Aktualna prędkość: ",-30}{Predkosc} {JednostkaPredkosci}" : "Nie");
            string czyPojazdMaSilnik = (this is ISilnik ? $"Tak\n{"Rodzaj napędu: ",-30}{Silnik}\n{"Moc silnika: ",-30}{MocSilnika} KM" : "Nie");
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
                $"{"Pojazd silnikowy: ",-30}{czyPojazdMaSilnik}\n" +
                $"{"Ilość kół: ",-30}{LiczbaKol}\n" +
                $"{"Wyporność: ",-30}{Wypornosc} kg\n";
        }

        // W klasie reprezentującej pojazd dostarcz statyczną metodę konwertującą szybkości z jednego systemu zapisu na inny.
        public static double MileMorskieNaKilometry(double x)
        {
            return Math.Round(x * 1.85199, 2);
        }

        public static double KilometryNaMileMorskie(double x)
        {
            return Math.Round(x * 0.53996, 2);
        }
    }
}