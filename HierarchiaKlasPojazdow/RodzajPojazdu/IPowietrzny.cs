namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface IPowietrzny //: IPojazd
    {
        public const int MaksymalnaPredkosc = 200;
        public const int MinimalnaPredkosc = 20;
        public const int Przyspieszenie = 40;
        public const string JednostkaPredkosci = "m/s";
        public static string MetryNaKilometry(double x)
        {
            return $"{Math.Round(x * 3.60000, 5)} km/h";
        }

        public static string MetryNaMileMorskie(double x)
        {
            return $"{Math.Round(x * 1.94385, 5)} węzły";
        }
    }
}