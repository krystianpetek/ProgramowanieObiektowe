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
            }
        }

        public virtual double MinimalnaPredkosc
        {
            get
            {
                double minimalnaPredkosc = default;

                if (aktualneSrodowisko == Srodowisko.Ladowe)
                    minimalnaPredkosc = ILadowy.MinimalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Wodne)
                    minimalnaPredkosc = IWodny.MinimalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    minimalnaPredkosc = IPowietrzny.MinimalnaPredkosc;

                return minimalnaPredkosc;
            }
        }

        public virtual double MaksymalnaPredkosc
        {
            get
            {
                double maksymalnaPredkosc = default;

                if (aktualneSrodowisko == Srodowisko.Ladowe)
                    maksymalnaPredkosc = ILadowy.MaksymalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Wodne)
                    maksymalnaPredkosc = IWodny.MaksymalnaPredkosc;

                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    maksymalnaPredkosc = IPowietrzny.MaksymalnaPredkosc;

                return maksymalnaPredkosc;
            }
        }

        public virtual double Przyspieszenie
        {
            get
            {
                double przyspieszenie = default;

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

        public virtual bool CzyMoznaPojazdZatrzymac
        {
            get
            {
                bool zatrzymaj = true;
                if (aktualneSrodowisko == Srodowisko.Powietrzne)
                    zatrzymaj = false;
                return zatrzymaj;
            }
        }

        protected double predkosc;

        public double Predkosc
        {
            get { return Math.Round(predkosc, 2); }
            init { predkosc = 0; }
        }

        protected bool czyPoruszaSie;

        public bool CzyPoruszaSie
        {
            get { return czyPoruszaSie; }
            init { czyPoruszaSie = false; }
        }

        protected Srodowisko aktualneSrodowisko { get; set; } = Srodowisko.Ladowe;
        public Srodowisko AktualneSrodowisko => aktualneSrodowisko;
        protected List<Srodowisko> dostepneSrodowisko { get; init; } = new List<Srodowisko>();

        public virtual void ZmniejszPredkosc(int interwalZmianyPredkosci)
        {
            if (interwalZmianyPredkosci < 1)
                return;

            if (this is ILadowy && this is IPowietrzny && aktualneSrodowisko == Srodowisko.Powietrzne)
            {
                double poZwolnieniu = Predkosc - interwalZmianyPredkosci * Przyspieszenie;
                if (IPowietrzny.MetryNaKilometry(poZwolnieniu) <= IPowietrzny.MinimalnaPredkosc)
                {
                    aktualneSrodowisko = Srodowisko.Ladowe;
                    predkosc = IPowietrzny.MetryNaKilometry(poZwolnieniu);
                    if (Predkosc <= 0)
                        predkosc = ILadowy.MinimalnaPredkosc;
                    Console.WriteLine($"Zwalniam, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
                    return;
                }
            }

            if (Predkosc == MinimalnaPredkosc)
            {
                Console.WriteLine("Poruszam się z minimalną prędkością, nie mogę już bardziej zwolnić");
                return;
            }
            if (Predkosc - interwalZmianyPredkosci * Przyspieszenie < MinimalnaPredkosc)
            {
                predkosc = MinimalnaPredkosc;
            }
            else
            {
                predkosc -= interwalZmianyPredkosci * Przyspieszenie;
            }
            Console.WriteLine($"Zwalniam, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
        }

        public void ZmniejszPredkosc()
        {
            ZmniejszPredkosc(1);
        }

        public virtual void ZwiekszPredkosc(int interwalZmianyPredkosci)
        {
            if (interwalZmianyPredkosci < 1)
                return;

            if (this is ILadowy && this is IPowietrzny && aktualneSrodowisko == Srodowisko.Ladowe)
            {
                double poPrzyspieszeniu = Predkosc + interwalZmianyPredkosci * Przyspieszenie;
                if (ILadowy.KilometryNaMetry(poPrzyspieszeniu) >= IPowietrzny.MinimalnaPredkosc)
                {
                    aktualneSrodowisko = Srodowisko.Powietrzne;
                    predkosc = ILadowy.KilometryNaMetry(poPrzyspieszeniu);
                    Console.WriteLine($"Przyśpieszam, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
                    return;
                }
            }
            if (!CzyPoruszaSie)
            {
                Start();
            }
            if (Predkosc >= MaksymalnaPredkosc)
            {
                Console.WriteLine("Poruszam się z maksymalną prędkością, nie mogę już bardziej przyśpieszyć");
                return;
            }

            if (Predkosc + interwalZmianyPredkosci * Przyspieszenie > MaksymalnaPredkosc)
            {
                predkosc = MaksymalnaPredkosc;
            }
            else
            {
                predkosc += interwalZmianyPredkosci * Przyspieszenie;
                czyPoruszaSie = true;
            }
            Console.WriteLine($"Przyśpieszam, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
        }

        public void ZwiekszPredkosc()
        {
            ZwiekszPredkosc(1);
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
            if (!CzyMoznaPojazdZatrzymac)
            {
                Console.WriteLine("Nie można zatrzymać pojazdu w powietrzu");
                return;
            }
            if (!CzyPoruszaSie)
            {
                Console.WriteLine("Pojazd nie porusza się");
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
                $"{"Aktualne środowisko: ",-30}{aktualneSrodowisko}\n" +
                $"{"Predkość minimalna: ",-30}{ ILadowy.MinimalnaPredkosc}\n" +
                $"{"Predkość maksymalna: ",-30}{ ILadowy.MaksymalnaPredkosc}\n" +
                $"{"Czy pojazd porusza się: ",-30}{czyPoruszaSie}\n";
        }

        public void ZmienSrodowisko()
        {
            if (this is IWodny && this is ILadowy)
            {
                if (aktualneSrodowisko == Srodowisko.Ladowe)
                {
                    aktualneSrodowisko = Srodowisko.Wodne;
                    if (ILadowy.KilometryNaMileMorskie(Predkosc) > IWodny.MaksymalnaPredkosc)
                        predkosc = IWodny.MaksymalnaPredkosc;
                    else
                        predkosc = ILadowy.KilometryNaMileMorskie(Predkosc);
                }
                else
                {
                    aktualneSrodowisko = Srodowisko.Ladowe;
                    predkosc = IWodny.MileMorskieNaKilometry(Predkosc);
                }
                Console.WriteLine($"Zmieniam środowisko, aktualna prędkość: {Predkosc} {JednostkaPredkosci}");
            }
        }

        public static int PorownajDwaPojazdy(Pojazd x, Pojazd y)
        {
            double xPredkosc = 0.0;
            double yPredkosc = 0.0;
            if (x.AktualneSrodowisko == Srodowisko.Ladowe)
                xPredkosc = x.Predkosc;
            if (x.AktualneSrodowisko == Srodowisko.Wodne)
                xPredkosc = IWodny.MileMorskieNaKilometry(x.Predkosc);
            if (x.AktualneSrodowisko == Srodowisko.Powietrzne)
                xPredkosc = IPowietrzny.MetryNaKilometry(x.Predkosc);

            if (y.AktualneSrodowisko == Srodowisko.Ladowe)
                yPredkosc = y.Predkosc;
            if (y.AktualneSrodowisko == Srodowisko.Wodne)
                yPredkosc = IWodny.MileMorskieNaKilometry(y.Predkosc);
            if (y.AktualneSrodowisko == Srodowisko.Powietrzne)
                yPredkosc = IPowietrzny.MetryNaKilometry(y.Predkosc);

            int wynik = 0;
            if (xPredkosc > yPredkosc)
                wynik = -1;
            if (xPredkosc == yPredkosc)
                wynik = 0;
            if (xPredkosc == yPredkosc)
                wynik = 1;

            return wynik;
        }
    }
}