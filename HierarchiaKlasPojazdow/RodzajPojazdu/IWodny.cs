namespace HierarchiaKlasPojazdow
{
    internal interface IWodny : IPojazd
    {
        public const int MaksymalnaPredkosc = 40;
        public const int MinimalnaPredkosc = 1;
        public const string JednostkaPredkosci = "węzeł";
        public static int Wypornosc { get; set; }
    }
}