namespace HierarchiaKlasPojazdow
{
    internal interface ILadowy : IPojazd
    {
        public const int MaksymalnaPredkosc = 350;
        public const int MinimalnaPredkosc = 1;
        public const string JednostkaPredkosci = "km/h";
        public static int LiczbaKol { get; set; }
    }
}