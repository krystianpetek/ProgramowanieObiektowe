using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface ILadowy
    {
        public const int MaksymalnaPredkosc = 350;
        public const int MinimalnaPredkosc = 1;
        public const int Przyspieszenie = 50;
        public const string JednostkaPredkosci = JednostkiPredkosci.KilometryNaGodzine;
        public abstract int LiczbaKol { get; init; }

        public static string KilometryNaMileMorskie(double x)
        {
            return $"{Math.Round(x * 0.53996, 5)} {JednostkiPredkosci.MilaMorskaNaGodzine}";
        }

        public static string KilometryNaMetry(double x)
        {
            return $"{Math.Round(x * 0.27778, 5)} {JednostkiPredkosci.MetryNaSekunde}";
        }
    }
}