using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow.Pojazdy
{
    internal class Samochod : Pojazd, ILadowy, ISilnik
    {
        public Samochod(RodzajSilnika silnik, double mocSilnika) : base()
        {
            MocSilnika = mocSilnika;
            Silnik = silnik;
            LiczbaKol = 4;
            aktualneSrodowisko = Srodowisko.Ladowe;
        }

        public RodzajSilnika Silnik { get; init; }
        public double MocSilnika { get; init; }
        public int LiczbaKol { get; init; }

        public override string ToString()
        {
            string czyPoruszaSie = ((CzyPoruszaSie) ? $"Tak\n{"Aktualna prędkość: ",-30}{Predkosc} {JednostkaPredkosci}" : "Nie");
            string czyPojazdMaSilnik = (this is ISilnik ? $"Tak\n{"Rodzaj napędu: ",-30}{Silnik}\n{"Moc silnika: ",-30}{MocSilnika}" : "Nie");
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
            return $"{"\nTyp pojazdu: ",-31}{GetType().Name}\n" +
                $"{"Możliwe środowiska pojazdu: ",-30}{srodowiska}\n" +
                $"{"Predkość minimalna: ",-30}{ MinimalnaPredkosc}\n" +
                $"{"Predkość maksymalna: ",-30}{ MaksymalnaPredkosc}\n" +
                $"{"Aktualne środowisko: ",-30}{aktualneSrodowisko}\n" +
                $"{"Czy pojazd porusza się: ",-30}{czyPoruszaSie}\n" +
                $"{"Pojazd silnikowy: ",-30}{czyPojazdMaSilnik}\n" +
                $"{"Ilość kół: ",-30}{LiczbaKol}\n";
        }
    }
}