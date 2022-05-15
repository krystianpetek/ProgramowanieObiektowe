string s = "Krzysztof Molenda, 1965-11-20; Jan Kowalski, 1987-01-01; Anna Abacka, 1972-05-20; Józef Kabacki, 2000-01-02; Kazimierz Moksa, 2001-01-02";

// flow
var queryFlow = s.Split(";")
    .Select( osoba => osoba.Trim())
    .Select( osoba => osoba.Replace(",", ""))
    .Select( osoba => osoba.Split(" "))
    .Select( osoba => new {imie = osoba[0], nazwisko= osoba[1], dataUrodzenia = osoba[2]})
    .OrderBy(osoba => osoba.dataUrodzenia)
    .ThenBy(osoba => osoba.nazwisko)
    .Select(osoba => osoba.nazwisko + " " + osoba.imie + " " + osoba.dataUrodzenia)
    .ToList();

string wynik = string.Join("\n",queryFlow);
Console.WriteLine(wynik);

// query
var splitted = s.Split(";");

var queryQuery = from osoba in splitted
    let osobaSplit = osoba.Trim().Replace(",","").Split(" ")
    let imie = osobaSplit[0]
    let nazwisko = osobaSplit[1]
    let dataUrodzenia = osobaSplit[2]
    orderby dataUrodzenia, nazwisko
    select new { imie, nazwisko, dataUrodzenia };

Console.WriteLine();
foreach (var item in queryQuery)
{
    Console.WriteLine($"{item.nazwisko} {item.imie} {item.dataUrodzenia}");
}