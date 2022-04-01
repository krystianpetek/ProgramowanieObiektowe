namespace HierarchiaKlasPojazdow
{
    internal interface IPowietrzny : IPojazd
    {
        public const int MaksymalnaPredkosc = 350;
        public const int MinimalnaPredkosc = 1;
        public const string JednostkaPredkosci = "m/s";
    }
}
