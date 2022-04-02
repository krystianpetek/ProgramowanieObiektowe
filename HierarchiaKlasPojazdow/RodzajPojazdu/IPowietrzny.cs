namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface IPowietrzny //: IPojazd
    {
        public const int MaksymalnaPredkosc = 200;
        public const int MinimalnaPredkosc = 20;
        public const int Przyspieszenie = 40;
        public const string JednostkaPredkosci = "m/s";
    }
}