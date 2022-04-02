using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.RodzajPojazdu;

namespace HierarchiaKlasPojazdow.Pojazdy
{
    internal class Samolot : IPowietrzny, ISilnik
    {
        public int Predkosc => throw new NotImplementedException();

        public bool CzyPoruszaSie => throw new NotImplementedException();

        public RodzajSilnika Silnik { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public double MocSilnika { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public Samolot()
        {
        }

        public void ZwiekszPredkosc()
        {
            Console.WriteLine($"Przyśpieszanie, aktualna prędkość: " + Predkosc);
        }

        public void ZmniejszPredkosc()
        {
            Console.WriteLine($"Zwalnianie, aktualna prędkość: " + Predkosc);
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}