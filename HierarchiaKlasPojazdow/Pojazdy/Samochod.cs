using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow.Pojazdy
{
    internal class Samochod : Pojazd, ILadowy, ISilnik
    {
        public Samochod(RodzajSilnika silnik, double mocSilnika) : base()
        {
            _predkosc = 0;
            _czyPoruszaSie = false;
            MocSilnika = mocSilnika;
            Silnik = silnik;
            LiczbaKol = 4;
            aktualneSrodowisko = Srodowisko.Ladowe;
        }
        private int _predkosc;
        private bool _czyPoruszaSie;

        public RodzajSilnika Silnik { get; init; }
        public double MocSilnika { get; init; }

        public override int Predkosc
        {
            get { return _predkosc; }
            init { _predkosc = 0; }
        }

        public override bool CzyPoruszaSie
        {
            get { return _czyPoruszaSie; }
            init { _czyPoruszaSie = false; }
        }

        public override Srodowisko aktualneSrodowisko { get; set; }
        public int LiczbaKol { get; init; }
        public override List<Srodowisko> dostepneSrodowisko { get;init; } = new List<Srodowisko>();

        public override void Start()
        {
            _czyPoruszaSie = true;
            _predkosc = ILadowy.MinimalnaPredkosc;
            Console.WriteLine($"Startuje, aktualna prędkość: {Predkosc} {ILadowy.JednostkaPredkosci}");
        }

        public override void Stop()
        {
            _predkosc = 0;
            _czyPoruszaSie = false;
            Console.WriteLine("Zatrzymuje się");
        }

        public override void ZwiekszPredkosc()
        {
            if (!CzyPoruszaSie)
            {
                Start();
            }

            if (Predkosc == ILadowy.MaksymalnaPredkosc)
            {
                Console.WriteLine("Jadę z maksymalną prędkością");
                return;
            }

            if (_predkosc + ILadowy.Przyspieszenie > ILadowy.MaksymalnaPredkosc)
            {
                _predkosc = ILadowy.MaksymalnaPredkosc;
            }
            else
            {
                _predkosc += ILadowy.Przyspieszenie;
                _czyPoruszaSie = true;
            }
            Console.WriteLine($"Przyśpieszam, aktualna prędkość: {Predkosc} {ILadowy.JednostkaPredkosci}");
        }

        public override void ZmniejszPredkosc()
        {
            if (Predkosc == ILadowy.MinimalnaPredkosc)
            {
                Console.WriteLine("Jadę z minimalną prędkością");
                return;
            }
            if (Predkosc - ILadowy.Przyspieszenie < ILadowy.MinimalnaPredkosc)
            {
                _predkosc = ILadowy.MinimalnaPredkosc;
            }
            else
            {
                _predkosc -= ILadowy.Przyspieszenie;
            }
            Console.WriteLine($"Zwalniam, aktualna prędkość: {Predkosc} {ILadowy.JednostkaPredkosci}");
        }

        public override string ToString()
        {
            string czyPoruszaSie = ((CzyPoruszaSie) ? "Tak\nAktualna prędkość: ".PadRight(30) + $"{Predkosc} {ILadowy.JednostkaPredkosci}\n" : "Nie");
            string czyPojazdMaSilnik = (this is ISilnik ? "Tak" : "Nie");
            string srodowiska = "";
            for (int i = 0; i < dostepneSrodowisko.Count; i++)
            {
                if (i == dostepneSrodowisko.Count-1)
                {
                    srodowiska += $"{dostepneSrodowisko[i]}";
                    break;
                }
                srodowiska += $"{dostepneSrodowisko[i]}, ";
            }
            return $"{"Typ pojazdu: ",-30}{GetType().Name}\n" +
                $"{"Mozliwe środowiska pojazdu: ",-30}{srodowiska}\n" +
                $"{"Predkość minimalna: ",-30}{ ILadowy.MinimalnaPredkosc}\n" +
                $"{"Prędkość maksymalna: ",-30}{ ILadowy.MaksymalnaPredkosc}\n" +
                $"{"Aktualne środowisko: ",-30}{aktualneSrodowisko}\n" +
                $"{"Czy porusza się: ",-30}{czyPoruszaSie}\n" +
                //$"Aktualna prędkość: ".PadRight(30) + $"{Predkosc} {ILadowy.JednostkaPredkosci}\n" +
                $"{"Pojazd silnikowy: ",-30}{czyPojazdMaSilnik}\n" +
                $"{"Ilosc kół: ",-30}{LiczbaKol}\n";
        }
    }
}