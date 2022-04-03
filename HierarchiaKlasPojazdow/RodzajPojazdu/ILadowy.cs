using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface ILadowy
    {
        public const double MaksymalnaPredkosc = 350;
        public const double MinimalnaPredkosc = 1;
        public const double Przyspieszenie = 50;
        public const string JednostkaPredkosci = JednostkiPredkosci.KilometryNaGodzine;
        public const bool czyMoznaZatrzymac = true;

        public abstract int LiczbaKol { get; init; }

        public static double KilometryNaMileMorskie(double x)
        {
            return Math.Round(x * 0.53996, 2);
        }

        public static double KilometryNaMetry(double x)
        {
            return Math.Round(x * 0.27778, 2);
        }
    }
}