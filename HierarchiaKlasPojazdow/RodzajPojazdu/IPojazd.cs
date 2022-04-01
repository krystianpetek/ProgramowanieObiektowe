namespace HierarchiaKlasPojazdow
{
    internal interface IPojazd
    {
        abstract void Start();
        abstract void Stop();
        int Predkosc { get; }
        bool CzyPoruszaSie { get; }
        void ZwiekszPredkosc();
        public void ZmniejszPredkosc()
        {
            Console.WriteLine($"Zwalnianie, aktualna prędkość: " + Predkosc);
        }

    }
}