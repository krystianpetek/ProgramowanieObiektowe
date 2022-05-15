namespace Zadanie_LinqToObject_SortowanieWedlugNazwiskIImion;

public class Osoba
{
    public string Imie { get; set; }   
    public string Nazwisko { get; set; }
    public override string ToString() => $"({Imie}; {Nazwisko})";
}