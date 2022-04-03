using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface IWodny
    {
        public const double MaksymalnaPredkosc = 40;
        public const double MinimalnaPredkosc = 1;
        public const double Przyspieszenie = 10;
        public const string JednostkaPredkosci = JednostkiPredkosci.MilaMorskaNaGodzine;
        public const bool czyMoznaZatrzymac = true;

        public abstract int Wypornosc { get; init; }

        public static double MileMorskieNaKilometry(double x)
        {
            return Math.Round(x * 1.85199, 2);
        }

        public static double MileMorskieNaMetry(double x)
        {
            return Math.Round(x * 0.51444, 2);
        }
    }
}