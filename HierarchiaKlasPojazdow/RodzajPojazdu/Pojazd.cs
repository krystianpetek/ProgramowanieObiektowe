using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal abstract partial class Pojazd
    {
        public static double KilometryNaMileMorskie(double x)
        {
            return Math.Round(x * 0.53996, 5);
        }

        public static double KilometryNaMetry(double x)
        {
            return Math.Round(x * 0.27778, 5);
        }

        public static double MetryNaKilometry(double x)
        {
            return Math.Round(x * 3.60000, 5);
        }

        public static double MetryNaMileMorskie(double x)
        {
            return Math.Round(x * 1.94385, 5);
        }

        public static double MileMorskieNaKilometry(double x)
        {
            return Math.Round(x * 1.85199, 5);
        }

        public static double MileMorskieNaMetry(double x)
        {
            return Math.Round(x * 0.51444, 5);
        }

        public Pojazd()
        {
            dostepneSrodowisko = new List<Srodowisko>();
            if(this is IPowietrzny)
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

        public abstract int Predkosc { get; init; }

        public virtual void ZmniejszPredkosc()
        {
            Console.Write($"Zwalnianie");
        }

        public virtual void ZwiekszPredkosc()
        {
            Console.Write($"Przyśpieszanie");
        }

        public virtual void Start()
        {
            Console.WriteLine($"Jedź");
        }

        public virtual void Stop()
        {
            Console.WriteLine($"Stój");
        }

        public abstract bool CzyPoruszaSie { get; init; }

        public abstract Srodowisko aktualneSrodowisko { get; set; }
        public abstract List<Srodowisko> dostepneSrodowisko {get;set;}
    }
}