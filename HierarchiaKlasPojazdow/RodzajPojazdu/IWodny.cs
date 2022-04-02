namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface IWodny //: IPojazd
    {
        public const int MaksymalnaPredkosc = 40;
        public const int MinimalnaPredkosc = 1;
        public const int Przyspieszenie = 10;
        public const string JednostkaPredkosci = "węzeł";
        public static int Wypornosc { get; set; }
        public static string MileMorskieNaKilometry(double x)
        {
            return $"{Math.Round(x * 1.85199, 5)} km/h";
        }

        public static string MileMorskieNaMetry(double x)
        {
            return $"{Math.Round(x * 0.51444, 5)} m/s";
        }
    }
}