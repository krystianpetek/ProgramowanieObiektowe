using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow
{
    internal class Samochod : Pojazd, ILadowy, ISilnik
    {
        public Samochod(RodzajSilnika silnik, double mocSilnika)
        {
            _predkosc = 0;
            _czyPoruszaSie = false;
            MocSilnika = mocSilnika;
            Silnik = silnik;
            LiczbaKol = 4;
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

        public override Srodowisko srodowisko { get; set; }
        public int LiczbaKol { get; init; }

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
            return $"{this.GetType()}{srodowisko}\nCzy porusza się: {CzyPoruszaSie}\nMinPredkosc: {ILadowy.MinimalnaPredkosc}\nMaxPredkosc: {ILadowy.MaksymalnaPredkosc}\n" +
                $"Aktualna prędkość: {Predkosc}\nIlosc kół: {LiczbaKol}\nPojazd silnikowy{((this is ISilnik) ? true : false)}";
        }
    }
}