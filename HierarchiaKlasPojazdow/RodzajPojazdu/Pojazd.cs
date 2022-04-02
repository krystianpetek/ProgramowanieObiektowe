using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    public abstract class Pojazd
    {
        internal Pojazd()
        {
            if (this is IPowietrzny)
            {
                dostepneSrodowisko.Add(Srodowisko.Powietrzne);
                aktualneSrodowisko = Srodowisko.Powietrzne;
            }
            if (this is IWodny)
            {
                dostepneSrodowisko.Add(Srodowisko.Wodne);
                aktualneSrodowisko = Srodowisko.Wodne;
            }
            if (this is ILadowy)
            {
                dostepneSrodowisko.Add(Srodowisko.Ladowe);
                aktualneSrodowisko = Srodowisko.Ladowe;
                return;
            }
        }

        public int MinimalnaPredkosc
        {
            get
            {
                int minimalnaPredkosc = default;

                if (aktualneSrodowisko == Srodowisko.Ladowe)
                    minimalnaPredkosc = ILadowy.MinimalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Wodne)
                    minimalnaPredkosc = IWodny.MinimalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    minimalnaPredkosc = IPowietrzny.MinimalnaPredkosc;

                return minimalnaPredkosc;
            }
        }

        public int MaksymalnaPredkosc
        {
            get
            {
                int maksymalnaPredkosc = default;

                if (aktualneSrodowisko == Srodowisko.Ladowe)
                    maksymalnaPredkosc = ILadowy.MaksymalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Wodne)
                    maksymalnaPredkosc = IWodny.MaksymalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    maksymalnaPredkosc = IPowietrzny.MaksymalnaPredkosc;

                return maksymalnaPredkosc;
            }
        }

        public int Przyspieszenie
        {
            get
            {
                int przyspieszenie = default;

                if (aktualneSrodowisko == Srodowisko.Ladowe)
                    przyspieszenie = ILadowy.Przyspieszenie;

                if (aktualneSrodowisko == Srodowisko.Wodne)
                    przyspieszenie = IWodny.Przyspieszenie;

                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    przyspieszenie = IPowietrzny.Przyspieszenie;

                return przyspieszenie;
            }
        }

        public string JednostkaPredkosci
        {
            get
            {
                string jednostkaPredkosci = "";

                if (aktualneSrodowisko == Srodowisko.Ladowe)
                    jednostkaPredkosci = JednostkiPredkosci.KilometryNaGodzine;

                if (aktualneSrodowisko == Srodowisko.Wodne)
                    jednostkaPredkosci = JednostkiPredkosci.MilaMorskaNaGodzine;

                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    jednostkaPredkosci = JednostkiPredkosci.MetryNaSekunde;

                return jednostkaPredkosci.ToString();
            }
        }

        protected double predkosc;

        public double Predkosc
        {
            get { return predkosc; }
            init { predkosc = 0; }
        }

        protected bool czyPoruszaSie;

        public bool CzyPoruszaSie
        {
            get { return czyPoruszaSie; }
            init { czyPoruszaSie = false; }
        }

        protected Srodowisko aktualneSrodowisko { get; set; } = Srodowisko.Ladowe;
        protected List<Srodowisko> dostepneSrodowisko { get; init; } = new List<Srodowisko>();

        public virtual void ZmniejszPredkosc()
        {
            if (Predkosc == MinimalnaPredkosc)
            {
                Console.WriteLine("Jadę z minimalną prędkością");
                return;
            }
            if (Predkosc - Przyspieszenie < MinimalnaPredkosc)
            {
                predkosc = MinimalnaPredkosc;
            }
            else
            {
                predkosc -= Przyspieszenie;
            }
            Console.WriteLine($"Zwalniam, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
        }

        public virtual void ZwiekszPredkosc()
        {
            if (!CzyPoruszaSie)
            {
                Start();
            }
            if (Predkosc >= MaksymalnaPredkosc)
            {
                Console.WriteLine("Jadę z maksymalną prędkością");
                return;
            }

            if (Predkosc + Przyspieszenie > MaksymalnaPredkosc)
            {
                predkosc = MaksymalnaPredkosc;
            }
            else
            {
                predkosc += Przyspieszenie;
                czyPoruszaSie = true;
            }
            Console.WriteLine($"Przyśpieszam, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
        }

        public virtual void Start()
        {
            if (CzyPoruszaSie)
            {
                Console.WriteLine("Pojazd jest już w ruchu");
                return;
            }
            czyPoruszaSie = true;
            predkosc = MinimalnaPredkosc;
            Console.WriteLine($"Startuje, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
        }

        public virtual void Stop()
        {
            if (!CzyPoruszaSie)
            {
                Console.WriteLine("Pojazd nie rusza się");
                return;
            }
            predkosc = 0;
            czyPoruszaSie = false;
            Console.WriteLine("Zatrzymuje się");
        }

        public override string ToString()
        {
            string czyPoruszaSie = ((CzyPoruszaSie) ? $"Tak\n{"Aktualna prędkość: ",-30}{Predkosc} {ILadowy.JednostkaPredkosci}" : "Nie");
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
                $"{"Predkość minimalna: ",-30}{ ILadowy.MinimalnaPredkosc}\n" +
                $"{"Predkość maksymalna: ",-30}{ ILadowy.MaksymalnaPredkosc}\n" +
                $"{"Aktualne środowisko: ",-30}{aktualneSrodowisko}\n" +
                $"{"Czy pojazd porusza się: ",-30}{czyPoruszaSie}\n";
        }

        public void TestowoPrzypiszSrodowisko(Srodowisko srodowisko)
        {
            aktualneSrodowisko = srodowisko;
        }
    }
}