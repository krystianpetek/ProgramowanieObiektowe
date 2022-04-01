namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal class Samolot : IPowietrzny, ISilnik
    {
        public Samolot()
        {
            Predkosc = 0;
        }
        public int Predkosc { get; set; }
        public bool CzyPoruszaSie { get; set; }
        public RodzajSilnika Silnik { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public double MocSilnika { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
        public void ZwiekszPredkosc()
        {
            Console.WriteLine($"Przyśpieszanie, aktualna prędkość: " + Predkosc);
        }
        public void ZmniejszPredkosc()
        {
            Console.WriteLine($"Zwalnianie, aktualna prędkość: " + Predkosc);
        }

    }
}
