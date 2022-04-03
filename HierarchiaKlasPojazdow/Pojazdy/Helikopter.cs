using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow.Pojazdy
{
    internal class Helikopter : Pojazd, IPowietrzny, ISilnik
    {
        public Helikopter(double mocSilnika) : base()
        {
            Silnik = RodzajSilnika.Turbowalowy;
            MocSilnika = mocSilnika;
        }

        public RodzajSilnika Silnik { get; init; }
        public double MocSilnika { get; init; }

        public override double MinimalnaPredkosc => 0.0;

        public override bool CzyMoznaPojazdZatrzymac
        {
            get
            {
                if (Predkosc == 0)
                    return true;
                return false;
            }
        }

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
                $"{"Pojazd silnikowy: ",-30}{czyPojazdMaSilnik}\n";
        }
    }
}