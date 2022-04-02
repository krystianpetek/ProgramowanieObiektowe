namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    internal interface ILadowy
    {
        public const int MaksymalnaPredkosc = 350;
        public const int MinimalnaPredkosc = 1;
        public const int Przyspieszenie = 50;
        public const string JednostkaPredkosci = "km/h";
        public abstract int LiczbaKol { get; init; }
    }
}