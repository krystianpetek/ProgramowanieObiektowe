using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface IPowietrzny
    {
        public const double MaksymalnaPredkosc = 200;
        public const double MinimalnaPredkosc = 20;
        public const double Przyspieszenie = 30;
        public const string JednostkaPredkosci = JednostkiPredkosci.MetryNaSekunde;
        public const bool czyMoznaZatrzymac = false;

        public static double MetryNaKilometry(double x)
        {
            return Math.Round(x * 3.60000, 2);
        }

        public static double MetryNaMileMorskie(double x)
        {
            return Math.Round(x * 1.94385, 2);
        }
    }
}