using Metody_Rozszerzajace;

string napis = "Ala ma kota, as to Ali pies";
Console.WriteLine(Utility.WordCount(napis));

Console.WriteLine(Utility.WordCount(napis, ' ', '\t', ',', '.', '!', '?', '`'));

Console.WriteLine(napis.WordCountExtended());

Console.WriteLine(napis.WordCountExtended(delimiters: new char[] { ' ', ',', '\t', ',', '.', '!', '?' }));
Console.WriteLine(napis.WordCountExtended(' ', ',', '\t', ',', '.', '!', '?'));

// zadanie 1
Console.WriteLine(napis.BezSamoglosek());

// zadanie 2
napis = "432";
Console.WriteLine(napis.IsNumeric());

// zadanie 3
var lista = new List<int> { 0, 1, 2, 3, 4 };
Console.WriteLine(lista.Dump());

// zadanie 4
var numDividedBy2 = from item in lista where item % 2 == 0 select item;
numDividedBy2.PrintLn();

// zadanie 5
int[] mediana = new int[] { 0, 1, 2, 2, 2, 2, 2, 3, 4, 6, 7, 8, 9, 9, 9, 10 };
Console.WriteLine(mediana.Mediana());

// zadanie 6
int liczba = 5;
Console.WriteLine(liczba.Between<int>(0, 9));
Console.WriteLine(liczba.Between<int>(0, 5));
Console.WriteLine(liczba.Between<int>(0, 4));
napis = "alicja";
Console.WriteLine(napis.Between("ala", "baba"));

// zadanie 7
Console.WriteLine(liczba.BetterBetween<int>(0, 9, (x, y) => x.CompareTo(y)));