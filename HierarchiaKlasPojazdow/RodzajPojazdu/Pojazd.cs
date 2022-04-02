using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    public abstract class Pojazd
    {
        internal Pojazd()
        {
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
        public abstract List<Srodowisko> dostepneSrodowisko {get;init;}
    }
}