namespace HierarchiaKlasPojazdow
{
    internal class Samochod : ILadowy, ISilnik
    {
        public Samochod()
        {
            _predkosc = 0;
            _czyPoruszaSie = false;
        }
        private int _predkosc;
        private bool _czyPoruszaSie;

        public int Predkosc => _predkosc;

        public bool CzyPoruszaSie => _czyPoruszaSie;

        public RodzajSilnika Silnik { get; init; }
        public double MocSilnika { get; init; }

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


    }
}